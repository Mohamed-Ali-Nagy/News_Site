using System.ComponentModel.DataAnnotations;

namespace News_Site.Models
{
    public class Category:BaseModel
    {
        [Required]
        public string Name { get; set; }
        public List<News>? NewsItems { get; set; }
    }
}
