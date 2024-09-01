using Microsoft.EntityFrameworkCore;
using News_Site.Helpers;
using News_Site.Models;
using News_Site.Repositories;
using News_Site.Services.Interfaces;
using News_Site.ViewModels.CategoryVMs;

namespace News_Site.Services.Classes
{
    public class CategoryService:ICategoryService
    {
        private IBaseRepository<Category> _repository;
        private INewsService _newsService;
        public CategoryService(IBaseRepository<Category> repository, INewsService newsService)
        {
            _repository = repository;
            _newsService = newsService;
        }

        public async Task<CategoryVM> GetByIDAsync(int id)
        {
            var category=await _repository.GetByIdAsync(id);
             return category.MapOne<CategoryVM>();
        }
        public async Task AddAsync(CategoryAddVM categoryAddVM)
        {
           await _repository.AddAsync(categoryAddVM.MapOne<Category>());
           await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
          var categories= await _repository.GetAll().ToListAsync();
          return categories.Select(c=>new CategoryVM { ID=c.ID,Name=c.Name});
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var category= await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            _repository.Delete(category);
           await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CategoryVM categoryVM)
        {
            var category=await _repository.GetByIdAsync(categoryVM.ID);
            if (category == null)
            {
                return false;
            }

            _repository.Update(categoryVM.MapOne<Category>());
            await _repository.SaveChangesAsync();
            return true;
        }


   
    }
}
