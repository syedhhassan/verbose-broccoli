using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Models
{
    public class CartResponseModel
    {
        public int ProductId { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }

        public int TotalQuantity { get; set; }
    }
}
