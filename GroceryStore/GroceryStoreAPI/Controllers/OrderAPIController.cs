using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {

        #region Declaration

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOrderService _orderService;

        #endregion

        #region Constructor

        public OrderAPIController(IHttpContextAccessor httpContextAccessor, IOrderService orderService)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderService = orderService;
        }

        #endregion

        #region Update Address
        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        [Route("updateaddress")]
        [HttpPost]
        public bool UpdateAddress(Guid UserId,  string Address)
        {
            return _orderService.UpdateAddress(UserId, Address);
        }
        #endregion

        #region Get orders
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("getorders")]
        [HttpGet]
        public List<OrderModel> GetOrders(Guid UserId)
        {
            return _orderService.GetOrders(UserId);
        }
        #endregion

        #region Get order items
        /// <summary>
        /// Get order items
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [Route("getorderitems")]
        [HttpGet]
        public List<OrderItemModel> GetOrderItems(Guid OrderId)
        {
            return _orderService.GetOrderItems(OrderId);
        }
        #endregion

        #region Check out a new order
        /// <summary>
        /// Check out a new order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [Route("neworder")]
        [HttpPost]
        public decimal NewOrder(Guid UserId)
        {
            return _orderService.NewOrder(UserId);
        }
        #endregion

    }
}
