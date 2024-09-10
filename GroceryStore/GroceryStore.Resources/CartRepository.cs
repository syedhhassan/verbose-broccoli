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
        public List<CartModel> FetchCart(Guid UserId)
        {       
            List<CartModel> cart = new List<CartModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    cart = connection.Query<CartModel>(SQLQueries.fetch_cart_data_query, new { USERID = UserId }).ToList();
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

        #region Add items to cart
        /// <summary>
        /// Add items to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool AddToCart(CartModel cart)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionstring))
                {
                    connection.Open();
                    connection.Execute(SQLQueries.add_to_cart_query, new { PRODUCTID = cart.ProductId, QUANTITY = cart.Quantity, USERID = cart.UserId, PRODUCTNAME = cart.ProductName, PRICE = cart.Price });
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

        #region Remove items from cart
        /// <summary>
        /// Remove items from cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public bool RemoveFromCart(CartModel cart)
        {
            return true;
        }
        #endregion

    }
}
