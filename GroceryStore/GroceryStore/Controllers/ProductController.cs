using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroceryStore.Controllers
{
    public class ProductController : Controller
    {

        #region Getting products
        /// <summary>
        /// Getting products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("mart")]
        public async Task<ActionResult> Mart()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                List<ProductModel> products = new List<ProductModel>();
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/ProductAPI/mart";
                    var response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<ProductModel>>(responseString);
                        return View(products);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                TempData["ToastrMessage"] = "Sign in first!";
                TempData["ToastrType"] = "warning";
                return RedirectToAction("SignIn", "User");
            }
            
        }
        #endregion

    }
}
