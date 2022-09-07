using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
                         // int PK seçmiş olduk string/guild yerine
    public class Role : IdentityRole<int>  /*EntityBase, IEntity*/
    {
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public ICollection<User> Users { get; set; }
    }
}