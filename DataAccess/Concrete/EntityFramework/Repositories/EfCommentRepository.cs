using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Shared.DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCommentRepository : EfEntityRepositoryBase<Comment>, ICommentRepository
    {
        public EfCommentRepository(DbContext context) : base(context)
        {
        }
    }
}
