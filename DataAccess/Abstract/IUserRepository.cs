using Entities.Concrete;
using Shared.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}