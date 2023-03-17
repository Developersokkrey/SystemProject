using Microsoft.AspNetCore.Mvc;

namespace SystemProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
