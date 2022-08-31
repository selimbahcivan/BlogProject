using Entities.Concrete;
using Shared.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ArticleListDto : DtoGetBase
    {
        public IList<Article> Articles { get; set; }
    }
}