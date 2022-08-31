using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.DTOs
{
    public class ArticleDto : DtoGetBase
    {
        public Article Article { get; set; }
    }
}