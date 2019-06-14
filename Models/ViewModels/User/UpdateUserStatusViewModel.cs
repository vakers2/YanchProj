using System.Collections.Generic;
using Entities.Enums;

namespace Models.ViewModels.User
{
    public class UpdateUserStatusViewModel
    {
        public List<string> UserIds;

        public UserStatus Status { get; set; }
    }
}
