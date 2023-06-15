using Application.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _appDbContext.RemoveRange(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _appDbContext.Set<T>().ToList();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _appDbContext.Set<T>().Update(entity);
        }
    }
}
