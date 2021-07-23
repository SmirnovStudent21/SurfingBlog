using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Псевдоним обязателен"), RegularExpression("^[а-яА-ЯёЁa-zA-Z0-9_]+$", ErrorMessage = "Неверный формат ввода псевдонима!")]
        [MaxLength(20), MinLength(3, ErrorMessage = "Минимальная длина псевдонима 3 символа")]
        public string Nickname { get; set; }
        [Required(ErrorMessage = "Почта обязательна")]
        [MaxLength(31), RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Неверный формат ввода адреса почты!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пароль обязателен"), RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Неверный формат ввода пароля!")]
        [MaxLength(20), MinLength(6, ErrorMessage = "Минимальная длина пароля 6 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повтор обязателен")]

        [NotMapped]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public String ConfirmPassword { get; set; }

        
        [MaxLength(31, ErrorMessage = "Максимальная длина — 31 символ")]
        public string Surname { get; set; }
        
        [MaxLength(31, ErrorMessage = "Максимальная длина — 31 символ")]
        public string Name { get; set; }
        [MaxLength(255, ErrorMessage = "Максимальная длина — 255 символов")]
        public string Contact { get; set; }
        [MaxLength(255, ErrorMessage = "Максимальная длина — 255 символов")]
        public string AboutMe { get; set; }
        [MaxLength(255, ErrorMessage = "Максимальная длина — 255 символов")]
        public string Progress { get; set; }
        public Guid? Photo { get; set; }

    }
}
