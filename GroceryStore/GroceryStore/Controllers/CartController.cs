using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace GroceryStore.Controllers
{
    public class CartController : Controller
    {
        #region Add items to cart
        /// <summary>
        /// Add items to cart
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ProductName"></param>
        /// <param name="Price"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addtocart")]
        public async Task<JsonResult> AddToCart(int ProductId, string ProductName, decimal Price)
        {
            int count = 0;
            CartModel cart = new CartModel();
            cart.ProductId = ProductId;
            cart.ProductName = ProductName;
            cart.Price = Price;
            cart.Quantity = 1;
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {                
                cart.UserId = new Guid(HttpContext.Session.GetString("UserId"));
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/CartAPI/register";
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(cart), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(requestUrl, jsonContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return Json(count);
                    }
                    else
                    {
                        TempData["ToastrMessage"] = "Email already exists. Please Sign In";
                        TempData["ToastrType"] = "warning";
                        return Json(count);
                    }
                }
            }
            return Json(count);
        }
        #endregion
    }
}
