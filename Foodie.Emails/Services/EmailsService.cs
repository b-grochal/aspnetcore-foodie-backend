using Foodie.Shared.Smtp;
using Foodie.Templates.Factories;
using Foodie.Templates.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Foodie.Templates.Services
{
    public interface IEmailsService
    {
        Task SendOrderStartedEmail(string toEmailAddress, long orderId);
        Task SendOrderInProgressEmail(string toEmailAddress, long orderId);
        Task SendOrderInDeliveryEmail(string toEmailAddress, long orderId);
        Task SendOrderDeliveredEmail(string toEmailAddress, long orderId);
        Task SendOrderCancelledEmail(string toEmailAddress, long orderId);
    }

    public class EmailsService : IEmailsService
    {
        private readonly IEmailMessageFactory emailsFactory;
        private readonly SmtpSettings smtpSettings;

        public EmailsService(IEmailMessageFactory emailsFactory, IOptions<SmtpSettings> smtpSettings)
        {
            this.emailsFactory = emailsFactory;
            this.smtpSettings = smtpSettings.Value; 
        }

        public async Task SendOrderCancelledEmail(string toEmailAddress, long orderId)
        {
            var orderCancelledEmailMessage = await emailsFactory.GenerateOrderCancelledMessage(toEmailAddress, orderId);
            await SendEmail(CreateMessage(orderCancelledEmailMessage));
        }

        public async Task SendOrderDeliveredEmail(string toEmailAddress, long orderId)
        {
            var orderDeliveredEmailMessage = await emailsFactory.GenerateOrderDeliveredMessage(toEmailAddress, orderId);
            await SendEmail(CreateMessage(orderDeliveredEmailMessage));
        }

        public async Task SendOrderInDeliveryEmail(string toEmailAddress, long orderId)
        {
            var orderInDeliveryEmailMessage = await emailsFactory.GenerateOrderInDeliveryMessage(toEmailAddress, orderId);
            await SendEmail(CreateMessage(orderInDeliveryEmailMessage));
        }

        public async Task SendOrderInProgressEmail(string toEmailAddress, long orderId)
        {
            var orderInProgressEmailMessage = await emailsFactory.GenerateOrderInProgressMessage(toEmailAddress, orderId);
            await SendEmail(CreateMessage(orderInProgressEmailMessage));
        }

        public async Task SendOrderStartedEmail(string toEmailAddress, long orderId)
        {
            var orderStartedEmailMessage = await emailsFactory.GenerateOrderStartedMessage(toEmailAddress, orderId);
            await SendEmail(CreateMessage(orderStartedEmailMessage));
        }

        private MimeMessage CreateMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtpSettings.DisplayName, smtpSettings.From));
            message.Sender = new MailboxAddress(smtpSettings.DisplayName, smtpSettings.From);

            foreach (string mailAddress in emailMessage.To)
                message.To.Add(MailboxAddress.Parse(mailAddress));

            message.Subject = message.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailMessage.Content };

            return message;
        }

        private async Task SendEmail(MimeMessage message)
        {
            using var smtp = new SmtpClient();

            if (smtpSettings.UseSsl)
            {
                await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.SslOnConnect);
            }
            else if (smtpSettings.UseStartTls)
            {
                await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls);
            }

            await smtp.AuthenticateAsync(smtpSettings.UserName, smtpSettings.Password);
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
