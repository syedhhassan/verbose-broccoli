using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IServices
{
    public interface ICartService
    {
        public List<CartModel> FetchCart(Guid UserId);

        public bool AddToCart(CartModel cart);
    }
}
