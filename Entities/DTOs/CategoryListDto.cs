using Entities.Concrete;
using Shared.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CategoryListDto : DtoGetBase
    {
        public IList<Category> Categories { get; set; }
    }
}