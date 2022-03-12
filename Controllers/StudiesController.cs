using Microsoft.AspNetCore.Mvc;
using MVCWebApplication.Models;
using MVCWebApplication.Models.Studies;
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

        [HttpPost]
        public async Task<IActionResult> AddNewStudy(Study study)
        {
            if (!ModelState.IsValid)
                return BadRequest("Missing data");

            if (study.Id == 0)
                _studyService.Add(study);
            else
                _studyService.Update(study);

            return await _studyService.SaveChangesAsync() ? Ok("Study added successfully") : BadRequest("Something went wrong");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudy(int id)
        {
            if (id <= 0) return BadRequest("Something went wrong");

            var studyData = await _studyService.GetStudyByIdAsync(id);

            if (studyData == null) return NotFound("Not found in database");

            _studyService.Delete(studyData);
            
            return await _studyService.SaveChangesAsync() ? Ok("Study deleted") : BadRequest("Something went wrong");
        }

        [HttpGet]
        public async Task<IActionResult> OpenDataRegModal(int id)
        {
            if(id != 0)
            {
                var study = await _studyService.GetStudyByIdAsync(id);

                return PartialView("~/Views/Studies/_DataForm.cshtml", study);
            }

            return PartialView("~/Views/Studies/_DataForm.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SearchStudies([FromBody]StudiesSearchDTO model)
        {
            if (String.IsNullOrWhiteSpace(model.searchString))
            {
                var allStudies = await _studyService.GetStudiesAsync();
                return PartialView("~/Views/Studies/_Studies.cshtml", allStudies.Studies.ToList());
            }

            var studies = await _studyService.GetSearchStudies(model.searchString);

            return PartialView("~/Views/Studies/_Studies.cshtml", studies);
        }
    }
}
