using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина псевдонима 3 символа")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MaxLength(20), MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string Login { get; set; }



    }
}
