using Microsoft.AspNetCore.Mvc;

namespace main.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
