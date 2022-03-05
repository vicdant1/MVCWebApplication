using MVCWebApplication.Data;
using MVCWebApplication.Repository.Interfaces;

namespace MVCWebApplication.Repository
{
    public class BaseRepository : IBaseRepository
    {
        AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _appDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appDbContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _appDbContext.Update(entity);
        }
    }
}
