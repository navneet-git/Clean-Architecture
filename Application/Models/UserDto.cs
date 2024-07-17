using Application.Common;

namespace Application.Models
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dob { get; set; }
        public string UserName { get; set; }

    }
}
