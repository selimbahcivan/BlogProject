using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
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
        private BlogContext BlogContext
        {
            get
            {
                return _context as BlogContext;
            }
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await BlogContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}