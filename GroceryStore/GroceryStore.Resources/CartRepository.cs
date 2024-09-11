using Dapper;
using GroceryStore.Core.IRepositories;
using GroceryStore.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Core.Utilities;
using System.Diagnostics;

namespace GroceryStore.Resources
{
    public class CartRepository : ICartRepository
    {
        #region Declaration

        private readonly string _connectionstring;

        #endregion

        #region Constructor

        public CartRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
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
            List<CartResponseModel> cart = new List<CartResponseModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    cart = connection.Query<CartResponseModel>(SQLQueries.fetch_cart_data_query, new { USERID = UserId }).ToList();
                    cart[0].TotalQuantity = connection.QuerySingle<int>(SQLQueries.total_quantity_query, new { USERID = UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return [];
            }
            return cart;
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
            int count = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    connection.Execute(SQLQueries.add_to_cart_query, new { PRODUCTID = cart.ProductId, QUANTITY = 1, USERID = cart.UserId });
                    count = connection.QuerySingle<int>(SQLQueries.item_quantity_query, new { PRODUCTID = cart.ProductId, USERID = cart.UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return -1;
            }
            return count;
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
            int count;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    connection.Execute(SQLQueries.remove_from_cart_query, new { PRODUCTID = cart.ProductId, QUANTITY = 1, USERID = cart.UserId });
                    count = connection.QuerySingle<int>(SQLQueries.item_quantity_query, new { PRODUCTID = cart.ProductId, USERID = cart.UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return -1;
            }
            return count;
        }
        #endregion

        #region Delete one item fully from cart
        /// <summary>
        /// Delete one item fully from cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool DeleteItem(int ProductId, Guid UserId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    connection.Execute(SQLQueries.delete_item_from_cart_query, new { PRODUCTID = ProductId, USERID = UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return true;
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
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    connection.Execute(SQLQueries.delete_cart_for_user_query, new { USERID = UserId });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return true;
        }
        #endregion

    }
}
