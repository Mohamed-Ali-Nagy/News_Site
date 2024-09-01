using News_Site.ViewModels.NewsVMs;

namespace News_Site.Services.Interfaces
{
    public interface INewsService
    {
        public Task AddAsync(NewsAddVM newsAddVM);
        public Task<NewsUpdateVM> GetByIDAsync(int id);
        public  Task<bool> UpdateAsync(NewsUpdateVM newsUpdateVM);
        public  Task<bool> DeleteAsync(int id);
        public  Task<NewsDetailsVM> GetDetailsAsync(int id);
        public Task<IEnumerable<NewsListVM>> GetAllAsync();
        public Task<IEnumerable<NewsListVM>> GetByCategoryIDyAsync(int? categoryID);
        public  Task<bool> HasNewsByCategoryAsync(int categoryId);
    }
}
