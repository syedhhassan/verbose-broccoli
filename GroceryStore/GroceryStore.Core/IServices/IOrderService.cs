using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IServices
{
    public interface IOrderService
    {
        public List<OrderModel> GetOrders(Guid UserId);

        public List<OrderItemModel> GetOrderItems(Guid OrderId);

        public bool NewOrder(Guid UserId);
    }
}
