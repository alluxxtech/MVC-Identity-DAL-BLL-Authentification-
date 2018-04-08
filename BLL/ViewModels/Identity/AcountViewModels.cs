using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels.Identity
{

    public enum UserStatus
    {
        Error = 0,
        Success = 1,
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Електрона адреса")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Passport { get; set; }

        [Display(Name = "Запамятати мене?")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        
        [Required]
        [EmailAddress(ErrorMessage = "Поле некоректное")]
        [Display(Name = "Електроный адрес")]
        public string Email { get; set; }

        [Required]        
        [StringLength(16, ErrorMessage = "Минимальная длина 6", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }


    }
}
