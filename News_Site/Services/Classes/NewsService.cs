using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using News_Site.Helpers;
using News_Site.Models;
using News_Site.Repositories;
using News_Site.Services.Interfaces;
using News_Site.ViewModels.NewsVMs;

namespace News_Site.Services.Classes
{
    public class NewsService : INewsService
    {
        private IBaseRepository<News> _repository;
        private IFileService _fileService;
        public NewsService(IBaseRepository<News> repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;

        }
        public async Task AddAsync(NewsAddVM newsAddVM)
        {
            News news = newsAddVM.MapOne<News>();
            news.NewsDate = DateTime.Now;
            if (newsAddVM.Image != null && newsAddVM.Image.Length != 0)
            {
                news.ImageURL = await _fileService.Upload(newsAddVM.Image);
            }
            await _repository.AddAsync(news);
            await _repository.SaveChangesAsync();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var news = await _repository.GetByIdAsync(id);
            if (news != null)
            {
                _repository.Delete(news);
                if (news.ImageURL != null)
                {
                    _fileService.DeletePhysicalFile(news.ImageURL);
                }
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<IEnumerable<NewsListVM>> GetAllAsync()
        {
            var news = await _repository.GetAll().ToListAsync();
            return news.Select(n => new NewsListVM { ID = n.ID, Title = n.Title });
        }

        public async Task<IEnumerable<NewsListVM>> GetByCategoryIDyAsync(int? categoryID)
        {
            var query = _repository.GetAll();
            if (categoryID.HasValue)
            {
                query = query.Where(n => n.CategoryId == categoryID);
            }
            var news = await query.ToListAsync();

            return news.Select(n => new NewsListVM { ID = n.ID, Title = n.Title });
        }

        public async Task<NewsUpdateVM> GetByIDAsync(int id)
        {
            News news = await _repository.GetByIdAsync(id);
            return news.MapOne<NewsUpdateVM>();
        }

        public async Task<NewsDetailsVM> GetDetailsAsync(int id)
        {
            var news = await _repository.GetAll(n => n.ID == id).Include("Category").FirstOrDefaultAsync();
            return news!.MapOne<NewsDetailsVM>();
        }
        public async Task<bool> UpdateAsync(NewsUpdateVM newsUpdateVM)
        {

            var news = await _repository.GetByIdAsync(newsUpdateVM.ID);
            if (news == null)
            {
                return false;
            }
            if (newsUpdateVM.Image != null)
            {
                newsUpdateVM.ImageURL = await _fileService.Upload(newsUpdateVM.Image);
                _fileService.DeletePhysicalFile(news.ImageURL!);
            }
            _repository.Update(newsUpdateVM.MapOne<News>());
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasNewsByCategoryAsync(int categoryId)
        {

            var hasNews = await _repository.GetAll().AnyAsync(n => n.CategoryId == categoryId);
            if(hasNews)
            {
                return true;
            }
            return false;

        }
    }
}
