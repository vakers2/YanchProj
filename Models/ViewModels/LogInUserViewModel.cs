using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
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
