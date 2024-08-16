using Microsoft.AspNetCore.Mvc;

namespace GroceryStore.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("mart")]
        public IActionResult Mart()
        {
            return View();
        }
    }
}
