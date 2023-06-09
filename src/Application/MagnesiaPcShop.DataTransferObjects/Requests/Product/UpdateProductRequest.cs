using System.ComponentModel.DataAnnotations;

namespace MagnesiaPcShop.DataTransferObjects.Requests.Product
{
    public class UpdateProductRequest
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adını boş bırakmayınız.")]
        [MaxLength(25,ErrorMessage = "En fazla 25 karakter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen ürün fiyatını giriniz.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Lütfen bir resim seçiniz.")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [MaxLength(50,ErrorMessage = "En fazla 50 karakter")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int? CategoryId { get; set; }
    }
}