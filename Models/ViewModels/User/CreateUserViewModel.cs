using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [MinLength(4, ErrorMessage = "Минимальная длина логина: 4 символов")]
        [MaxLength(64, ErrorMessage = "Максимальная длина логина: 64 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени: 2 символов")]
        [MaxLength(64, ErrorMessage = "Максимальная длина имени: 64 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения")]
        [MinLength(8, ErrorMessage = "Минимальная длина пароля: 8 символов")]
        [MaxLength(64, ErrorMessage = "Максимальная длина пароля: 64 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
