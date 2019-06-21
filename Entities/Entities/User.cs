using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(UserStatus.Pending)]
        public UserStatus Status { get; set; }

        public List<UserChat> UserChats { get; set; }
    }
}
