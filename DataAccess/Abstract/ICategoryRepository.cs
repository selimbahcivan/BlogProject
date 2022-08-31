using Entities.Concrete;
using Shared.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}