using News_Site.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels.NewsVMs
{
    public class NewsUpdateVM
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100.")] 
        public string Title { get; set; }
        [Required]

        public string Body { get; set; }
        public DateTime NewsDate { get; set; }

        public string? ImageURL { get; set; }
        public IFormFile? Image { get; set; }
        public int CategoryId { get; set; }
    }
}
