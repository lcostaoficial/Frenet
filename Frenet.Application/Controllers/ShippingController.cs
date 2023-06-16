using Microsoft.AspNetCore.Mvc;

namespace Frenet.Application.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Quote()
        {
            return View();
        }
    }
}