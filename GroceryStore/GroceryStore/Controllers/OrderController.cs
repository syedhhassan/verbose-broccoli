using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroceryStore.Controllers
{
    public class OrderController : Controller
    {

        #region Get orders
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetOrders(Guid UserId)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                string sessionuser = HttpContext.Session.GetString("UserId");
                List<OrderModel> orders = new List<OrderModel>();
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/OrderAPI/getorders?UserId={sessionuser}";
                    var response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        orders = JsonConvert.DeserializeObject<List<OrderModel>>(responseString);
                        return Json(orders);
                    }
                    else
                    {
                        return Json(orders);
                    }
                }
            }
            return Json(new { error = "User not logged in" });
        }
        #endregion

        #region Get order items
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetOrderItems(Guid OrderId)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {              
                List<OrderItemModel> items = new List<OrderItemModel>();
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/OrderAPI/getorderitems?OrderId={OrderId}";
                    var response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<OrderItemModel>>(responseString);
                        return Json(items);
                    }
                    else
                    {
                        return Json(items);
                    }
                }
            }
            return Json(new { error = "User not logged in" });
        }
        #endregion

        #region Check out a new order
        /// <summary>
        /// Check out a new order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> NewOrder(Guid UserId)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                List<OrderItemModel> items = new List<OrderItemModel>();
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/OrderAPI/getorderitems?UserId={UserId}";
                    var response = await client.PostAsync(requestUrl, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<OrderItemModel>>(responseString);
                        return Json(items);
                    }
                    else
                    {
                        return Json(items);
                    }
                }
            }
            return Json(new { error = "User not logged in" });
        }
        #endregion

    }
}
