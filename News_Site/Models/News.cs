using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace News_Site.Models
{
    public class News : BaseModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title length can't be more than 100.")] 
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime NewsDate { get; set; } 
        public string? ImageURL { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
