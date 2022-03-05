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

        public async Task<Study> GetStudyByIdAsync(int id)
        {
            return await _appDbContext.Studies.Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
