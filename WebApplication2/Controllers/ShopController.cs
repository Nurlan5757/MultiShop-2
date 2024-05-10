using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ShopController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
