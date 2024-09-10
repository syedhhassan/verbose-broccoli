using GroceryStore.Core.IServices;
using GroceryStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        #region Declarations

        private readonly ILogger<UserAPIController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserAPIController(ILogger<UserAPIController> logger, IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        #endregion

        #region Sign Up
        /// <summary>
        /// Sign Up
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("register")]
        [HttpPost]
        public bool SignUp(UserModel user)
        {
            return _userService.SignUp(user);
        }
        #endregion

        #region Sign In
        /// <summary>
        /// Sign In
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("login")]
        [HttpPost]
        public Dictionary<string, string> SignIn(UserModel user)
        {
            return _userService.SignIn(user);
        }
        #endregion
    }
}
