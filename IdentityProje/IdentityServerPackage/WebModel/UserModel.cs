using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerPackage.WebModel
{
    public class UserModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı gereklidir.")]
        [Display(Name = "Kullanıcı Adı Giriniz")]

        public string UserName { get; set; }

        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
