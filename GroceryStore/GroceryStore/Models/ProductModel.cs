namespace GroceryStore.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Price { get; set; }

        public string? Quantity { get; set; }

        public enum Category
        {
            dairy,
            fruits,
            vegetables,
            staple,
            drinks,
            spices,
            meat
        }
    }
}
