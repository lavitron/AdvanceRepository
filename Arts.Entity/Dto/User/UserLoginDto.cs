using Core.Entity;

namespace Arts.Entity.Dto.User
{
    public class UserLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}