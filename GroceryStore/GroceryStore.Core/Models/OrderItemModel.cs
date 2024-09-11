using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Models
{
    public class OrderItemModel
    {
        public string? Name {  get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public float TotalPrice { get; set; }
    }
}
