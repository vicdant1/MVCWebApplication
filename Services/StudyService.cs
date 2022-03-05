using MVCWebApplication.Data;
using MVCWebApplication.Models.Studies;
using MVCWebApplication.Models.ViewModel;
using MVCWebApplication.Repository.Interfaces;

namespace MVCWebApplication.Services
{
    public class StudyService
    {
        AppDbContext _appDbContext;
        IStudyRepository _studyRepository;
        public StudyService(AppDbContext appDbContext, IStudyRepository studyRepository)
        {
            _appDbContext = appDbContext;
            _studyRepository = studyRepository;
        }

        public async Task<StudyViewModel> GetStudiesAsync()
        {
            var studies = await _studyRepository.GetStudiesAsync();

            return new StudyViewModel(studies);
        }


        public Task<Study> GetStudyByIdAsync(int id) => _studyRepository.GetStudyByIdAsync(id);

        public void Add(Study study) => _studyRepository.Add(study);

        public void Delete(Study study) => _studyRepository.Delete(study);

        public void Update(Study study) => _studyRepository.Update(study);

        public async Task<bool> SaveChangesAsync() => await _studyRepository.SaveChangesAsync();

    }
}
