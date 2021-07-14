using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace SurfClub.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина псевдонима 3 символа")]
        public string Nickname { get; set; }
        
        [Required(ErrorMessage = "Псевдоним обязателен")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина псевдонима 3 символа")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [MaxLength(20), MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Введите пароль ещё раз")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
        
        [MaxLength(31, ErrorMessage = "Максимальная длина — 31 символ")]
        public string Surname { get; set; }

        [MaxLength(31, ErrorMessage = "Максимальная длина — 31 символ")]
        public string Name { get; set; }
        
        public string Contact { get; set; }
        public string AboutMe { get; set; }
        public string Progress { get; set; }
        public Guid Photo { get; set; }
        public string Register { get; set; }

    }
}
