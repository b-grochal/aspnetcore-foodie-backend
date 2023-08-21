using Foodie.Templates.Models;
using Foodie.Templates.Renderer;
using Foodie.Templates.Views.Emails.MyAccount.AccountActivation;
using Foodie.Templates.Views.Emails.MyAccount.SetPassword;
using Foodie.Templates.Views.Emails.Orders.OrderCancelled;
using Foodie.Templates.Views.Emails.Orders.OrderDelivered;
using Foodie.Templates.Views.Emails.Orders.OrderInDelivery;
using Foodie.Templates.Views.Emails.Orders.OrderInProgress;
using Foodie.Templates.Views.Emails.Orders.OrderStarted;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Templates.Factories
{
    public interface IEmailMessageFactory
    {
        Task<EmailMessage> GenerateOrderStartedMessage(string toAddress, long orderId);
        Task<EmailMessage> GenerateOrderInProgressMessage(string toAddress, long orderId);
        Task<EmailMessage> GenerateOrderInDeliveryMessage(string toAddress, long orderId);
        Task<EmailMessage> GenerateOrderDeliveredMessage(string toAddress, long orderId);
        Task<EmailMessage> GenerateOrderCancelledMessage(string toAddress, long orderId);
        Task<EmailMessage> GenerateAccountActivationMessage(string toAddress, string accountActivationToken);
        Task<EmailMessage> GenerateSetPasswordMessage(string toAddress, string setPasswordToken);
    }

    public class EmailMessageFactory : IEmailMessageFactory
    {
        private readonly IViewsRenderer viewsRenderer;

        public EmailMessageFactory(IViewsRenderer viewsRenderer)
        {
            this.viewsRenderer = viewsRenderer;
        }

        public async Task<EmailMessage> GenerateAccountActivationMessage(string toAddress, string accountActivationToken)
        {
            var accountActivationEmialViewModel = new AccountActivationEmailViewModel
            {
                AccountActivationToken = accountActivationToken
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/MyAccount/AccountActivation/AccountActivationEmail.cshtml", accountActivationEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateOrderCancelledMessage(string toAddress, long orderId)
        {
            var orderCancelledEmialViewModel = new OrderCancelledEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderCancelled/OrderCancelledEmail.cshtml", orderCancelledEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateOrderDeliveredMessage(string toAddress, long orderId)
        {
            var orderDeliveredEmialViewModel = new OrderDeliveredEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderDelivered/OrderDeliveredEmail.cshtml", orderDeliveredEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateOrderInDeliveryMessage(string toAddress, long orderId)
        {
            var orderInDeliveryEmialViewModel = new OrderInDeliveryEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderInDelivery/OrderInDeliveryEmail.cshtml", orderInDeliveryEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateOrderInProgressMessage(string toAddress, long orderId)
        {
            var orderInProgressEmialViewModel = new OrderInProgressEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderInProgress/OrderInProgressEmail.cshtml", orderInProgressEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateOrderStartedMessage(string toAddress, long orderId)
        {
            var orderStartedEmialViewModel = new OrderStartedEmailViewModel
            {
                OrderId = orderId
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/Orders/OrderStarted/OrderStartedEmail.cshtml", orderStartedEmialViewModel),
                To = new List<string> { toAddress }
            };
        }

        public async Task<EmailMessage> GenerateSetPasswordMessage(string toAddress, string setPasswordToken)
        {
            var setPasswordEmialViewModel = new SetPasswordEmailViewModel
            {
                SetPasswordToken = setPasswordToken
            };

            return new EmailMessage
            {
                Content = await viewsRenderer.RenderView("/Views/Emails/MyAccount/SetPassword/SetPasswordEmail.cshtml", setPasswordEmialViewModel),
                To = new List<string> { toAddress }
            };
        }
    }
}
