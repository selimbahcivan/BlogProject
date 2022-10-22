using System.Threading.Tasks;
using Shared.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
