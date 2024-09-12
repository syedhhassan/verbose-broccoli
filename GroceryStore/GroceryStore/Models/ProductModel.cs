namespace GroceryStore.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Quantity { get; set; }

        public string? Category { get; set; }

        public string? Path { get; set; }

        public int ProductQuantity { get; set; }

    }
}
