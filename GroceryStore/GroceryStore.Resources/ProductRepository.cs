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


namespace GroceryStore.Resources
{
    public class ProductRepository : IProductRepository
    {

        #region Declaration

        private readonly string _connectionstring;

        #endregion

        #region Constructor

        public ProductRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        #endregion

        #region Get products
        /// <summary>
        /// Get products
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<ProductModel> GetProducts(Guid UserId)
        {
            List<ProductModel> products = new List<ProductModel>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();
                    products = connection.Query<ProductModel>(SQLQueries.get_products_query, new { @USERID = UserId }).ToList();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return products;
        }
        #endregion

        #region Search products
        /// <summary>
        /// Search products
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="SearchQuery"></param>
        /// <returns></returns>
        public List<ProductModel> SearchProducts(Guid UserId, string SearchQuery)
        {
            List<ProductModel> products = new List<ProductModel>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();
                    products = connection.Query<ProductModel>(SQLQueries.product_search_query, new { @USERID = UserId, @SEARCHQUERY = SearchQuery }).ToList();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return products;
        }
        #endregion
    }
}
