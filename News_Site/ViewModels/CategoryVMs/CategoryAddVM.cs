using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels.CategoryVMs
{
    public class CategoryAddVM
    {
        [Required]
        public string Name { get; set; }

    }
}
