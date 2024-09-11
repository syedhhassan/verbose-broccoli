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
        public List<CartResponseModel> FetchCart(Guid UserId)
        {
            return _cartRepository.FetchCart(UserId);
        }
        #endregion

        #region Add item to cart
        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int AddToCart(CartRequestModel cart)
        {
            return _cartRepository.AddToCart(cart);
        }
        #endregion

        #region Remove item from cart
        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int RemoveFromCart(CartRequestModel cart)
        { 
            return _cartRepository.RemoveFromCart(cart);
        }
        #endregion

        #region Delete one item fully from cart
        /// <summary>
        /// Delete one item fully from cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<CartResponseModel> DeleteItem(int ProductId, Guid UserId)
        {
            List<CartResponseModel> cart = new List<CartResponseModel>();
            bool isDeleted = _cartRepository.DeleteItem(ProductId, UserId);
            if (isDeleted)
            {
                cart = _cartRepository.FetchCart(UserId);
            }
            return cart;
        }
        #endregion

        #region Delete cart for user
        /// <summary>
        /// Delete cart for user
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteCart(Guid UserId)
        {
            return _cartRepository.DeleteCart(UserId);
        }
        #endregion

    }
}
