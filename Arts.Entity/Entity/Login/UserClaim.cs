using Core.Entity;

namespace Arts.Entity.Entity.Login
{
    public class UserClaim : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User UserFk { get; set; }

        public int LoginClaimId { get; set; }
        public virtual LoginClaim LoginClaimFk { get; set; }
    }
}