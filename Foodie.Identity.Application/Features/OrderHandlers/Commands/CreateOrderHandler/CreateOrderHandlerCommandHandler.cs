using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.OrderHandlers;
using Foodie.Templates.Services;
using Hangfire;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommandHandler : IRequestHandler<CreateOrderHandlerCommand, Result<CreateOrderHandlerCommandResponse>>
    {
        private readonly IOrderHandlersRepository _orderHandlersRepository;
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderHandlerCommandHandler(
            IOrderHandlersRepository orderHandlersRepository, 
            IApplicationUsersRepository applicationUsersRepository, 
            IPasswordService passwordService, 
            IMapper mapper, 
            ICacheService cacheService, 
            IBackgroundJobClient backgroundJobClient, 
            IEmailsService emailsService, 
            IUnitOfWork unitOfWork)
        {
            _orderHandlersRepository = orderHandlersRepository;
            _applicationUsersRepository = applicationUsersRepository;
            _passwordService = passwordService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateOrderHandlerCommandResponse>> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
        {
            if (!await _applicationUsersRepository.IsEmailUniqueAsync(request.Email))
                return Result.Failure<CreateOrderHandlerCommandResponse>(ApplicationUserErrors.ApplicationUserAlreadyExists(request.Email));

            var passwordHash = _passwordService.HashPassword(request.Password);

            var orderHandler = OrderHandler.Create(request.FirstName, request.LastName, request.Email, request.PhoneNumber, passwordHash, request.LocationId);

            await _orderHandlersRepository.CreateAsync(orderHandler);

            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return _mapper.Map<CreateOrderHandlerCommandResponse>(orderHandler);
        }
    }
}
