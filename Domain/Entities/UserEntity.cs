using Domain.Common;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Dob { get; set; }
        public string UserName { get; set; }

    }
}
