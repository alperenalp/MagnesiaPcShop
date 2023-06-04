namespace MagnesiaPcShop.DataTransferObjects.Responses.Product
{
    public class ProductDisplayResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}