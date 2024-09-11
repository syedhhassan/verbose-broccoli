using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {

        #region Declaration

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartService _cartService;

        #endregion

        #region Constructor

        public CartAPIController(IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
        }

        #endregion

        #region Fetch cart data
        /// <summary>
        /// Fetch cart data
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("fetchcart")]
        [HttpGet]
        public List<CartResponseModel> FetchCart(Guid UserId)
        {
            return _cartService.FetchCart(UserId);
        }
        #endregion

        #region Add item to cart
        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [Route("addtocart")]
        [HttpPost]
        public int AddToCart(CartRequestModel cart)
        {
            return _cartService.AddToCart(cart);
        }
        #endregion

        #region Remove item from cart
        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [Route("removefromcart")]
        [HttpPost]
        public int RemoveFromCart(CartRequestModel cart)
        {
            return _cartService.RemoveFromCart(cart);
        }
        #endregion

        #region Delete one item fully from cart
        /// <summary>
        /// Delete one item fully from cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("deleteitem")]
        [HttpPost]
        public List<CartResponseModel> DeleteItem(int ProductId, Guid UserId)
        {
            return _cartService.DeleteItem(ProductId, UserId);
        }
        #endregion

        #region Delete cart for user
        /// <summary>
        /// Delete cart for user
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("deletecart")]
        [HttpPost]
        public bool DeleteCart(Guid UserId)
        {
            return _cartService.DeleteCart(UserId);
        }
        #endregion

    }
}
