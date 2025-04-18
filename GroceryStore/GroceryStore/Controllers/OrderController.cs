﻿using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace GroceryStore.Controllers
{
    public class OrderController : Controller
    {

        #region Confirm shipping address
        /// <summary>
        /// Confirm shipping address
        /// </summary>
        /// <returns></returns>
        public IActionResult ConfirmAddress()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Address")))
            {
                ViewData["Address"] = HttpContext.Session.GetString("Address");
                return View();
            }
            return RedirectToAction("GetAddress");
        }
        #endregion

        #region Get shipping address
        /// <summary>
        ///Get shipping address
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAddress()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region Get shipping address post action
        /// <summary>
        /// Get shipping address post action
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> GetAddress(AddressModel address)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                string sessionuser = HttpContext.Session.GetString("UserId");
                string shipAddress = $"{address.AddressLine1}, {address.AddressLine2}, {address.City}, {address.Zip}.";
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/OrderAPI/updateaddress?UserId={sessionuser}&Address={shipAddress}";
                    var response = await client.PostAsync(requestUrl, null);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetString("Address", shipAddress);
                        return RedirectToAction("Payment", "Order");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region Get orders
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetOrders(Guid UserId)
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
                        return View(orders);
                    }
                    else
                    {
                        return View(orders);
                    }
                }
            }
            return View(new { error = "User not logged in" });
        }
        #endregion

        #region Get order items
        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetOrderItems(Guid OrderId)
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
                        return View(items);
                    }
                    else
                    {
                        return View(items);
                    }
                }
            }
            return View(new { error = "User not logged in" });
        }
        #endregion

        #region Check out a new order
        /// <summary>
        /// Check out a new order
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> NewOrder()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                string sessionuser = HttpContext.Session.GetString("UserId");
                using (HttpClient client = new HttpClient())
                {
                    string requestUrl = $"https://localhost:7083/api/OrderAPI/neworder?UserId={sessionuser}";
                    var response = await client.PostAsync(requestUrl, null); 
                    var responseString = await response.Content.ReadAsStringAsync();
                    int total = JsonConvert.DeserializeObject<int>(responseString);
                    if (total > 0)
                    {
                        return RedirectToAction("OrderSuccess");
                    }
                    else
                    {
                        return RedirectToAction("Mart", "Product");
                    }
                }
            }
            return RedirectToAction("Mart", "Product");
        }
        #endregion

        #region Payment gateway
        /// <summary>
        /// Payment gateway
        /// </summary>
        /// <returns></returns>
        public IActionResult Payment()
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Email")) && !String.IsNullOrEmpty(HttpContext.Session.GetString("Address")))
            {
                TempData["Total"] = HttpContext.Session.GetString("Total");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region  Order success
        /// <summary>
        /// Order success
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderSuccess()
        {
            return View();
        }
        #endregion
    }
}
