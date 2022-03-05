using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
