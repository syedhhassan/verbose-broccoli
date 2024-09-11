using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System;

namespace GroceryStore.Models
{
    public class CartRequestModel
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }
        
    }
}