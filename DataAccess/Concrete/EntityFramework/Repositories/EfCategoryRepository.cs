using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository : EfEntityRepositoryBase<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
