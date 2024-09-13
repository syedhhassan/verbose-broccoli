using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Models
{
    public class OrderModel
    {

        public Guid OrderId { get; set; }

        public string? OrderDate { get; set; }

        public string? Address { get; set; }

        public float Total { get; set; }

        public string? Products { get; set; }

    }
}
