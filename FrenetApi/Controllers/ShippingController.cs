using Microsoft.AspNetCore.Mvc;

namespace FrenetApi.Controllers
{
    public class ShippingController : Controller
    {
        public IActionResult Quote()
        {
            return View();
        }
    }
}