using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        #region Declaration

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductAPIController(IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            _productService = productService;
        }

        #endregion

        #region Getting products
        /// <summary>
        /// Getting products
        /// </summary>
        /// <returns></returns>
        [Route("mart")]
        [HttpGet]
        public List<ProductModel> GetProducts()
        {
            return _productService.GetProducts();
        }
        #endregion

    }
}
