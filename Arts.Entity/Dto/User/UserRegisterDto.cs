using Core.Entity;

namespace Arts.Entity.Dto.User
{
    public class UserRegisterDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
    }
}