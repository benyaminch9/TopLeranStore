using Microsoft.AspNetCore.Mvc;

namespace TopLEarn.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
