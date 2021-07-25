using System.ComponentModel.DataAnnotations;

namespace Arts.Entity.Entity.Login
{
    public enum ClaimEnum
    {
        [Display(Name = "Admin")]
        Admin = 1,

        [Display(Name = "User")]
        User = 2,
    }
}