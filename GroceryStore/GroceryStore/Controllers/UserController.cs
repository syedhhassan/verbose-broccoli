﻿using Microsoft.AspNetCore.Mvc;
using System.Text;
using GroceryStore.Models;
using Newtonsoft.Json;

namespace GroceryStore.Controllers
{
    public class UserController : Controller
    {

		#region Sign In
		[Route("login")]
        public IActionResult SignIn()
        {
            HttpContext.Session.Clear();
            return View();
        }
        #endregion

        #region Sign up post action
        /// <summary>
        /// Sign up post action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> SignUp(UserModel user)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"https://localhost:7083/api/UserAPI/register";
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUrl, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Name", user.Name);
                    TempData["ToastrMessage"] = "Signed up successfully. You can sign in.";
                    TempData["ToastrType"] = "success";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ToastrMessage"] = "Email already exists. Please Sign In";
                    TempData["ToastrType"] = "warning";
                    return RedirectToAction("SignUp", user);
                }
            }
        }
		#endregion

        #region Sign in post action
        /// <summary>
        /// Sign in post action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> SignIn(UserModel user)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"https://localhost:7083/api/UserAPI/login";
                var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUrl, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);
                    var fan = responseData.GetType();
                    if (responseString != null && user.Email != null)
                    {
                        TempData["Email"] = user.Email;
                        HttpContext.Session.SetString("Email", user.Email);
                        HttpContext.Session.SetString("UserId", responseData["UserId"]);
                        HttpContext.Session.SetString("Name", responseData["Name"]);
                        return RedirectToAction("Mart", "Product");
                    }
                    else
                    {
                        TempData["ToastrMessage"] = "Sign in failed!";
                        TempData["ToastrType"] = "error";
                        return View();
                    }
                }
                else
                {
                    TempData["ToastrMessage"] = "Sign in failed!";
                    TempData["ToastrType"] = "error";
                    return View();
                }
            }
        }
        #endregion

    }
}
