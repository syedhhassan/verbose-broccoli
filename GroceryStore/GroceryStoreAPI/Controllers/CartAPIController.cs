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
        public List<CartModel> FetchCart(Guid UserId)
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
        public bool AddToCart(CartModel cart)
        {
            return _cartService.AddToCart(cart);
        }
        #endregion
    }
}

#region Cart Schema

//SELECT
//    o.OrderID,
//    o.CustomerID,
//    o.OrderDate,
//    CONCAT(o.ShippingStreetAddress, ', ', o.ShippingCity, ', ', o.ShippingState, ' ', o.ShippingZipCode) AS Address,
//    o.TotalAmount,
//    o.CreatedAt,
//    o.UpdatedAt,
//    oi.OrderItemID,
//    oi.ProductID,
//    p.ProductName, -- Assumes there is a ProductName field in the Products table
//    oi.Quantity,
//    oi.UnitPrice,
//    oi.TotalPrice
//FROM 
//    Orders o
//JOIN 
//    OrderItems oi ON o.OrderID = oi.OrderID
//JOIN 
//    Products p ON oi.ProductID = p.ProductID
//WHERE 
//    o.CustomerID = ?; --Replace ? with the specific CustomerID you want to query

#endregion
