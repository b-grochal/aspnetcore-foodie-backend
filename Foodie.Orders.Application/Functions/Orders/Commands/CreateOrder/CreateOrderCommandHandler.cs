using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        public Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.AddressStreet, request.AddressCity, request.AddressCountry);
            var order = new Order(request.UserId, request.UserEmail, address);
            throw new NotImplementedException();
        }
    }
}
