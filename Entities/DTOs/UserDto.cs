using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserDto:DtoGetBase
    {
        public User User { get; set; }
    }
}
