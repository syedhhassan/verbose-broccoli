using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }

        public string? Address { get; set; }

        public float Price { get; set; }

        public string? Products { get; set; }

    }
}
