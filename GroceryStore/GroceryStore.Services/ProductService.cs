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
    public class ProductService : IProductService
    {
        #region Declaration

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Get products
        /// <summary>
        /// Get products
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts(Guid UserId)
        {
            return _productRepository.GetProducts(UserId);
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
            return _productRepository.SearchProducts(UserId, SearchQuery);
        }
        #endregion

    }
}
