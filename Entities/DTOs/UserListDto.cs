using System.Collections.Generic;
using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
