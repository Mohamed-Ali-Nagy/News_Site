using System.ComponentModel.DataAnnotations;

namespace News_Site.ViewModels.NewsVMs
{
    public class NewsDetailsVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageURL { get; set; }
        public DateTime NewsDate { get; set; }
        public string CategoryName { get; set; }
    }
}
