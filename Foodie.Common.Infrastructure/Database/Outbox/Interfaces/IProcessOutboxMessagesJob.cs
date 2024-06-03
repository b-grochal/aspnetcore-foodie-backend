using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Outbox.Interfaces
{
    public interface IProcessOutboxMessagesJob
    {
        Task ProcessAsync();
    }
}
