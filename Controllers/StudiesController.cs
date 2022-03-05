using Microsoft.AspNetCore.Mvc;
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

            _studyService.Add(study);

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
    }
}
