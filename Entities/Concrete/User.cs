using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entities.Concrete
{
    // int PK seçmiş olduk string/guild yerine
    public class User : IdentityUser<int> /*EntityBase, IEntity*/
    {
        public string Picture { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}