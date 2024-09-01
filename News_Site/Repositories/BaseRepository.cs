using Microsoft.EntityFrameworkCore;
using News_Site.Data;
using News_Site.Models;
using System.Linq.Expressions;

namespace News_Site.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T : BaseModel
    {
        private Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }


        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).AsNoTracking();
        }

        public async Task<T> GetByIdAsync(int ID)
        {
            var entity = await GetAll().FirstOrDefaultAsync(x => x.ID == ID);
            return entity!;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
