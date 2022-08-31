using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}