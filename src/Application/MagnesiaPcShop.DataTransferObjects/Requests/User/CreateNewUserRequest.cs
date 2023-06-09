using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.User
{
    public class CreateNewUserRequest
    {
        [Required(ErrorMessage ="Lütfen isminizi giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Lütfen soyisminizi giriniz.")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Lütfen mailinizi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "En az 5 karakter girmelisiniz.")]
        public string Password { get; set; }
    }
}
