using System.Collections.Generic;
using Core.Entity;

namespace Arts.Entity.Entity.Login
{
    public class User : BaseEntity
    {
        public User()
        {
            UserClaims = new List<UserClaim>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual ICollection<UserClaim> UserClaims { get; set; }
    }
}