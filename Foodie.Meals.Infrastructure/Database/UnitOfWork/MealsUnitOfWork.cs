using Foodie.Common.Infrastructure.Database;

namespace Foodie.Meals.Infrastructure.Database.UnitOfWork
{
    public class MealsUnitOfWork : BaseUnitOfWork
    {
        public MealsUnitOfWork(MealsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
