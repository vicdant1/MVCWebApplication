using MVCWebApplication.Models.Studies;

namespace MVCWebApplication.Repository.Interfaces
{
    public interface IStudyRepository : IBaseRepository
    {
        Task<IEnumerable<Study>> GetStudiesAsync();
        Task<Study> GetStudyByIdAsync(int id);
    }
}
