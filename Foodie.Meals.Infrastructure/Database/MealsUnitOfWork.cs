using Foodie.Common.Infrastructure.Database;

namespace Foodie.Meals.Infrastructure.Database
{
    public class MealsUnitOfWork : UnitOfWork
    {
        public MealsUnitOfWork(MealsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
