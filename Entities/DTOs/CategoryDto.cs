using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.DTOs
{
    public class CategoryDto : DtoGetBase
    {
        public Category Category { get; set; }
    }
}