using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Data;
using MVCWebApplication.Models.Studies;
using MVCWebApplication.Repository.Interfaces;

namespace MVCWebApplication.Repository
{
    public class StudyRepository : BaseRepository, IStudyRepository
    {
        AppDbContext _appDbContext;
        public StudyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Study>> GetStudiesAsync()
        {
            return await _appDbContext.Studies.ToListAsync();
        }

        public Task<Study> GetStudyByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
