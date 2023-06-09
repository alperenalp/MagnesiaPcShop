using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.User
{
    public class ValidateUserLoginRequest
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "En az 5 karakter giriniz. ")]
        public string Password { get; set; }
    }
}
