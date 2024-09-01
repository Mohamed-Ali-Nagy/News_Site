using AutoMapper;
using News_Site.Models;
using News_Site.ViewModels.CategoryVMs;

namespace News_Site.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddVM, CategoryVM>().ReverseMap();
            CreateMap<CategoryAddVM, Category>().ReverseMap();
            CreateMap<CategoryVM, Category>().ReverseMap();
        }
    }
}
