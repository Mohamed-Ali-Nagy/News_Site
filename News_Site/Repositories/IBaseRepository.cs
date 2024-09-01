using System.Linq.Expressions;

namespace News_Site.Repositories
{
    public interface IBaseRepository<T>
    {
        public  Task<T> GetByIdAsync(int ID);
        public IQueryable<T> GetAll();
        public Task AddAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        public Task SaveChangesAsync();
    }
}
