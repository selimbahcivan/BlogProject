﻿using Shared.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public string UserName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ArticleId { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
