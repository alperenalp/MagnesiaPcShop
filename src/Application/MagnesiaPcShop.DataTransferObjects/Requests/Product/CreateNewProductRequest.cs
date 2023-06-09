using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.DataTransferObjects.Requests.Product
{
    public class CreateNewProductRequest
    {
        [Required(ErrorMessage ="Ürün adını boş bırakmayınız.")]
        [MaxLength(25, ErrorMessage = "En fazla 25 karakter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen ürün fiyatını giriniz.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Lütfen bir resim url giriniz.")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int CategoryId { get; set; }
    }
}
