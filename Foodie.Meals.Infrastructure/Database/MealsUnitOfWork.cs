using Foodie.Common.Infrastructure.Database;

namespace Foodie.Meals.Infrastructure.Database
{
    public class MealsUnitOfWork : BaseUnitOfWork
    {
        public MealsUnitOfWork(MealsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
