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
    public class OrderService : IOrderService
    {

        #region Declaration
        private readonly IOrderRepository _orderRepository ;
        #endregion

        #region Constructor
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        #endregion

        #region Get orders
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<OrderModel> GetOrders(Guid UserId)
        {
            return _orderRepository.GetOrders(UserId);
        }
        #endregion

        #region Get order items
        /// <summary>
        /// Get order items
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public List<OrderItemModel> GetOrderItems(Guid OrderId)
        {
            return _orderRepository.GetOrderItems(OrderId);
        }
        #endregion

        #region Check out a new order
        /// <summary>
        /// Check out a new order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool NewOrder(Guid UserId)
        {
            return _orderRepository.NewOrder(UserId);
        }
        #endregion

    }
}
