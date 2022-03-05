using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class EntertainmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
