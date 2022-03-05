using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Services;

namespace MVCWebApplication.Controllers
{
    public class StudiesController : Controller
    {
        StudyService _studyService;

        public StudiesController(StudyService studyService)
        {
            _studyService = studyService;
        }

        public async Task<IActionResult> Index()
        {
            var studies = await _studyService.GetStudiesAsync();

            return View(studies);
        }
    }
}
