using System.Collections.Generic;
using Entities.Concrete;

namespace CoreMVC.Areas.Admin.Models
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
