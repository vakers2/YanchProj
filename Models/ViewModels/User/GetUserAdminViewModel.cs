using Entities.Enums;

namespace Models.ViewModels.User
{
    public class GetUserAdminViewModel
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }

        public UserStatus Status { get; set; }
    }
}
