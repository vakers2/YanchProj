using Entities.Enums;

namespace Models.ViewModels.User
{
    public class GetUserViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public UserStatus Status { get; set; }
    }
}
