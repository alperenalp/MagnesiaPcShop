namespace MagnesiaPcShop.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string? Description { get; set; }

        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public IList<UserProductReviews> Reviews { get; set; }
        public IList<OrderDetails> Orders { get; set; }

    }
}