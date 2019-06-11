using Entities.Enums;

namespace Models.ViewModels.User
{
    public class UpdateUserStatusViewModel
    {
        public string UserId { get; set; }

        public UserStatus Status { get; set; }
    }
}
