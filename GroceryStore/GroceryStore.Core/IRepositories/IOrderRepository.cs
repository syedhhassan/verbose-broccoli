using GroceryStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Core.IRepositories
{
    public interface IOrderRepository
    {
        public bool UpdateAddress(Guid UserId, string Address);

        public List<OrderModel> GetOrders(Guid UserId);

        public List<OrderItemModel> GetOrderItems(Guid OrderId);

        public decimal NewOrder(Guid UserId);
    }
}
