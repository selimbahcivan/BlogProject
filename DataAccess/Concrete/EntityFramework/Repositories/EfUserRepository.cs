using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }
    }
}
