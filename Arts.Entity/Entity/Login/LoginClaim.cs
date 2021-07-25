using System.Collections.Generic;
using Core.Entity;

namespace Arts.Entity.Entity.Login
{
    public class LoginClaim : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}