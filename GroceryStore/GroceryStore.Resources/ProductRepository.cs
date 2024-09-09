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

        #region Getting products
        /// <summary>
        /// Getting products
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new List<ProductModel>();

            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                try
                {
                    connection.Open();
                    products = connection.Query<ProductModel>(SQLQueries.get_products_query).ToList();
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
