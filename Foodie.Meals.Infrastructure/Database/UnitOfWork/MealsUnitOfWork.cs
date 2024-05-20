using Foodie.Common.Infrastructure.Database.UnitOfWork;

namespace Foodie.Meals.Infrastructure.Database.UnitOfWork
{
    public class MealsUnitOfWork : BaseUnitOfWork
    {
        public MealsUnitOfWork(MealsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
