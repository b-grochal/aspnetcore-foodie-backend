using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Common.Infrastructure.Database.Outbox.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Dapper;
using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Common.Infrastructure.Database.Outbox
{
    public sealed class ProcessOutboxMessagesJob : IProcessOutboxMessagesJob
    {
        private const int BatchSize = 10;
        //TODO: Use System.Text.Json instead of Newtonsoft
        private readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        private readonly IDbConnecionFactory _dbConnecionFactory;
        private readonly IPublisher _publisher;
        private readonly ILogger<ProcessOutboxMessagesJob> _logger;

        public ProcessOutboxMessagesJob(
            IDbConnecionFactory dbConnecionFactory, 
            IPublisher publisher, 
            ILogger<ProcessOutboxMessagesJob> logger)
        {
            _dbConnecionFactory = dbConnecionFactory;
            _publisher = publisher;
            _logger = logger;
        }

        public async Task ProcessAsync()
        {
            try
            {
                _logger.LogInformation("Beginning to process outbox messages.");

                using IDbConnection dbConnection = _dbConnecionFactory.CreateConnection();
                dbConnection.Open();
                using IDbTransaction dbTransaction = dbConnection.BeginTransaction();

                IReadOnlyList<OutboxMessageResponse> outboxMessages = await GetOutboxMessagesAsync(dbConnection, dbTransaction);

                if (!outboxMessages.Any())
                {
                    _logger.LogInformation("Completed processing outbox messages - no messages to process.");

                    return;
                }

                foreach (var outboxMessage in outboxMessages)
                {
                    Exception? exception = null;

                    try
                    {
                        IDomainEvent domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
                            outboxMessage.Content,
                            _jsonSerializerSettings);

                        await _publisher.Publish(domainEvent);
                    }
                    catch (Exception caughtException)
                    {
                        _logger.LogError(caughtException,
                            "Exception while processing outbox message {MessageId}.",
                            outboxMessage.Id);

                        exception = caughtException;
                    }

                    await UpdateOutboxMessageAsync(dbConnection, dbTransaction, outboxMessage, exception);
                }

                dbTransaction.Commit();

                _logger.LogInformation("Completed processing outbox messages.");
            }
            catch(Exception ex) 
            {
                return;
            }
        }

        private async Task<IReadOnlyList<OutboxMessageResponse>> GetOutboxMessagesAsync(
            IDbConnection dbConnection,
            IDbTransaction dbTransaction)
        {
            string sql = """
                        SELECT TOP (@BatchSize) Id, Content
                        FROM OutboxMessages WITH (UPDLOCK, READPAST)
                        WHERE ProcessedDate IS NULL
                        ORDER BY OccurrenceDate
                        """;

            IEnumerable<OutboxMessageResponse> outboxMessages = await dbConnection.QueryAsync<OutboxMessageResponse>(
                sql,
                new { BatchSize },
                transaction: dbTransaction);

            return outboxMessages.ToList();
        }

        private async Task UpdateOutboxMessageAsync(
            IDbConnection dbConnection, 
            IDbTransaction dbTransaction, 
            OutboxMessageResponse outboxMessage, 
            Exception? exception)
        {
            // TODO: Try to make raw string
            const string sql = @"
                UPDATE OutboxMessages
                SET ProcessedDate = @ProcessedDate,
                    Error = @Error
                WHERE Id = @Id";

            await dbConnection.ExecuteAsync(
                sql,
                new
                {
                    outboxMessage.Id,
                    ProcessedDate = DateTimeOffset.Now,
                    Exception = exception?.ToString()
                },
                transaction: dbTransaction);
        }


        // TODO: Maybe move it somewhere
        internal sealed record OutboxMessageResponse(Guid Id, string Content);
    }
}
