using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.Models
{
    public class CartRequestModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }
    }
}
