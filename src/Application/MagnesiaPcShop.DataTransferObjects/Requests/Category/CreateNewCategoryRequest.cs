using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.Category
{
    public class CreateNewCategoryRequest
    {
        [Required(ErrorMessage = "Lütfen kategori seçiniz.")]
        [MinLength(3, ErrorMessage = "En az 3 karakter giriniz.")]
        [MaxLength(25, ErrorMessage = "En fazla 25 karakter giriniz.")]
        public string Name { get; set; }
    }
}
