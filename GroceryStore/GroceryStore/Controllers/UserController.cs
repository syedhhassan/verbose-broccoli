using Microsoft.AspNetCore.Mvc;
using System.Text;
using GroceryStore.Models;
using Newtonsoft.Json;

namespace GroceryStore.Controllers
{
    public class UserController : Controller
    {
        #region Sign Up 
        [Route("register")]
        public IActionResult SignUp()
        {
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

        [Route("login")]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
