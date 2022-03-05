using Microsoft.AspNetCore.Mvc;

namespace MVCWebApplication.Controllers
{
    public class StudiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
