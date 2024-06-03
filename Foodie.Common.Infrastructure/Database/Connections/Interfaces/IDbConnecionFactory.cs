using System.Data;

namespace Foodie.Common.Infrastructure.Database.Connections.Interfaces
{
    public interface IDbConnecionFactory
    {
        IDbConnection CreateConnection();
    }
}
