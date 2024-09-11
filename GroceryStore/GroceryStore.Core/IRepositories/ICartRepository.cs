using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IRepositories
{
    public interface ICartRepository
    {
        public List<CartResponseModel> FetchCart(Guid UserId);

        public int AddToCart(CartRequestModel cart);

        public int RemoveFromCart(CartRequestModel cart);

        public bool DeleteItem(int ProductId, Guid UserId);

        public bool DeleteCart(Guid UserId);

    }
}
