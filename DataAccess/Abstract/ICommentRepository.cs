using Entities.Concrete;
using Shared.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface ICommentRepository : IEntityRepository<Comment>
    {
    }
}