using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Users
{
    public class RegisterDTO
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string UserName { get; set; }

        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Compare(nameof(Password),ErrorMessage ="Şifreler Eşleşmiyor")]
        public string PasswordConfirm { get; set; }
    }
}
