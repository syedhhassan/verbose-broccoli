namespace GroceryStore.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }

        public string? Address { get; set; }

        public float Price { get; set; }

        public string? Products { get; set; }

    }
}
