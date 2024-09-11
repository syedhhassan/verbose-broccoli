namespace GroceryStore.Models
{
    public class OrderItemModel
    {

        public string? Name { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public float TotalPrice { get; set; }

    }
}
