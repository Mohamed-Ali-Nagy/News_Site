using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels.CategoryVMs
{
    public class CategoryVM
    {
        [Required]
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }
    }
}
