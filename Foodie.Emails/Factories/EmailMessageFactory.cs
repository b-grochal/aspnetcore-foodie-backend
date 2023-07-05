﻿using Foodie.Templates.Models;
using Foodie.Templates.Renderer;
using Foodie.Templates.Views.Emails.Orders.OrderInProgress;
using System.Threading.Tasks;

namespace Foodie.Templates.Factories
{
    public interface IEmailMessageFactory
    {
        Task<EmailMessage> GenerateOrderInProgressMessage(long orderId);
    }

    public class EmailMessageFactory : IEmailMessageFactory
    {
        private readonly IViewsRenderer viewsRenderer;

        public EmailMessageFactory(IViewsRenderer viewsRenderer)
        {
            this.viewsRenderer = viewsRenderer;
        }

        public async Task<EmailMessage> GenerateOrderInProgressMessage(long orderId)
        {
            var orderInProgressEmialViewModel = new OrderInProgressEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderInProgress/OrderInProgressEmail.cshtml", orderInProgressEmialViewModel)
            };
        }
    }
}