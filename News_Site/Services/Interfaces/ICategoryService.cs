using News_Site.ViewModels.CategoryVMs;

namespace News_Site.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task AddAsync(CategoryAddVM categoryAddVM);
        public Task<IEnumerable<CategoryVM>> GetAllAsync();
        public Task<bool> UpdateAsync(CategoryVM categoryVM);
        public  Task<bool> DeleteAsync(int id);

        public Task<CategoryVM> GetByIDAsync(int id);

    }
}
