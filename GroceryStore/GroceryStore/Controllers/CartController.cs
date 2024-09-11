using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GroceryStore.Controllers
{
    public class CartController : Controller
    {

        #region Fetch cart data
        /// <summary>
        /// Fetch cart data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> FetchCart()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                string sessionuser = HttpContext.Session.GetString("UserId");
                List<CartResponseModel> cart = new List<CartResponseModel>();
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/CartAPI/fetchcart?UserId={sessionuser}";
                    var response = await client.GetAsync(requestUrl);                    

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        cart = JsonConvert.DeserializeObject<List<CartResponseModel>>(responseString);
                        return View(cart);
                    }
                    else
                    {
                        return View(cart);
                    }
                }
            }
            return View(new { error = "User not logged in" });
        }
        #endregion

        #region Add item to cart
        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddToCart([FromBody] CartRequestModel cart)
        {
            int count = 0;
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                cart.UserId = new Guid(HttpContext.Session.GetString("UserId"));
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/CartAPI/addtocart";
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(requestUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        count = JsonConvert.DeserializeObject<int>(responseString);
                        return Json(count);
                    }
                    else
                    {
                        return Json(new { error = "Failed to add to cart" });
                    }
                }
            }
            return Json(count);
        }

        #endregion

        #region Remove item from cart
        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> RemoveFromCart([FromBody] CartRequestModel cart)
        {
            int count = 0;
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                cart.UserId = new Guid(HttpContext.Session.GetString("UserId"));
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/CartAPI/removefromcart";
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(requestUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        count = JsonConvert.DeserializeObject<int>(responseString);
                        return Json(count);
                    }
                    else
                    {
                        return Json(new { error = "Failed to remove from cart" });
                    }
                }
            }
            return Json(count);
        }
        #endregion

    }
}
