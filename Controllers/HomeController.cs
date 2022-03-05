using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using System.Diagnostics;

namespace MVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}