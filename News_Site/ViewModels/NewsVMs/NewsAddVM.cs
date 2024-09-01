using News_Site.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels.NewsVMs
{
    public class NewsAddVM
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100.")] 
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime NewsDate { get; set; } 
        public IFormFile? Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
