using Dapper;
using GroceryStore.Core.IRepositories;
using GroceryStore.Core.Models;
using GroceryStore.Core.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Resources
{
    public class OrderRepository : IOrderRepository
    {
        #region Declaration

        private readonly string _connectionstring;

        #endregion

        #region Constructor

        public OrderRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
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
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    orders = connection.Query<OrderModel>(SQLQueries.get_orders_query, new { @USERID = UserId }).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return orders;
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
            List<OrderItemModel> items = new List<OrderItemModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    items = connection.Query<OrderItemModel>(SQLQueries.get_order_items_query, new { @ORDERID = OrderId }).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return items;
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
            List<CartResponseModel> cart = new List<CartResponseModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    cart = connection.Query<CartResponseModel>(SQLQueries.fetch_cart_data_query, new { @USERID = UserId }).ToList();
                    string Address = connection.QuerySingle<string>(SQLQueries.get_address_query, new { @USERID = UserId });
                    decimal Price = 0;
                    foreach (var product in cart)
                    {
                        Price = Price + (product.Price * product.Quantity);
                    }
                    connection.Execute(SQLQueries.new_order_query, new { @USERID = UserId, @ADDRESS = Address, @TOTAL = Price });
                    Guid OrderId = connection.QuerySingle<Guid>(SQLQueries.get_orderid_query, new { @USERID = UserId });
                    foreach (var product in cart)
                    {
                        connection.Execute(SQLQueries.insert_order_items_query, new { @ORDERID = OrderId, @PRODUCTID = product.ProductId, @QUANTITY = product.Quantity, @UNITPRICE = product.Price });
                    }
                    connection.Execute(SQLQueries.delete_cart_for_user_query, new { @USERID = UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion
    }
}
