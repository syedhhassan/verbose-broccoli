using GroceryStore.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        #region Declaration

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICartService _cartService;

        #endregion

        #region Constructor

        public CartAPIController(IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
        }

        #endregion

    }
}
