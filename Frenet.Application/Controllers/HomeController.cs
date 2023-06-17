using Microsoft.AspNetCore.Mvc;

namespace Frenet.Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Quote", "Shipping");
        }
    }
}