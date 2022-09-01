using System;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        // Unit of Work patterni bize birden fazla repository ile yapılan işlemleri tek yerden yönetmemizi sağlar.
        // Transaction'da bir sıkıntı olduğunda işlemi iptal etmemizi sağlar.(Mesela birden fazla kayıt oluşmasın diye)
        // eg : _unitOfWork.Categories.AddAsync(category);
        //      _unitOfWork.Users.AddAsync(user);
        //      _unitOfWork.SaveAsync();
        IArticleRepository Articles { get; }

        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }

        // Identity Eklendiği için sildik.
        //IRoleRepository Roles { get; }
        //IUserRepository Users { get; }

        Task<int> SaveAsync();
    }
}