using Foodie.Templates.Factories;
using System.Threading.Tasks;

namespace Foodie.Templates.Services
{
    public interface IEmailsService
    {
        Task SendOrderInProgressEmail(string toEmailAddress, long orderId);
    }

    public class EmailsService : IEmailsService
    {
        private readonly IEmailMessageFactory emailsFactory;

        public EmailsService(IEmailMessageFactory emailsFactory)
        {
            this.emailsFactory = emailsFactory;
        }

        public async Task SendOrderInProgressEmail(string toEmailAddress, long orderId)
        {
            var orderInProgressEmailMessage = await emailsFactory.GenerateOrderInProgressMessage(orderId); 
        }
    }
}
