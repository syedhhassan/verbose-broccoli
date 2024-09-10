using GroceryStore.Core.IRepositories;
using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Services
{
    public class CartService : ICartService
    {
        #region Declaration

        private readonly ICartRepository _cartRepository;

        #endregion

        #region Constructor

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        #endregion

        #region Fetch cart data
        /// <summary>
        /// Fetch cart data
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<CartModel> FetchCart(Guid UserId)
        {
            return _cartRepository.FetchCart(UserId);
        }
        #endregion

        #region Add items to cart
        /// <summary>
        /// Add items to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool AddToCart(CartModel cart)
        {
            return _cartRepository.AddToCart(cart);
        }
        #endregion
    }
}
