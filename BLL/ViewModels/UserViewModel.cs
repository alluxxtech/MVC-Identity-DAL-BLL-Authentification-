using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
    }
    public class UserCreateViewModel
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

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public HttpPostedFileBase Image { get; set; }

    }
}
