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

        #region Getting products
        /// <summary>
        /// Getting products
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        #endregion

    }
}
