using AutoMapper;
using News_Site.Models;
using News_Site.ViewModels.NewsVMs;

namespace News_Site.Profiles
{
    public class NewsProfile:Profile
    {
        public NewsProfile()
        {
            CreateMap<NewsAddVM, News>();
            CreateMap<NewsUpdateVM, News>().ReverseMap();
            CreateMap<News, NewsListVM>();
            CreateMap<News, NewsDetailsVM>().ForMember(dst=>dst.CategoryName,opt=>opt.MapFrom(src=>src.Category.Name));
        }
    }
}
