using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.User
{
    public class LogInUserViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(64)]
        public string Login { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(64)]
        public string Password { get; set; }
    }
}
