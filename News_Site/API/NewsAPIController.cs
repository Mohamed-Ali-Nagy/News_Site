using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_Site.Services.Interfaces;

namespace News_Site.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsAPIController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsAPIController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetDetails(int id) 
        {
            var news= await _newsService.GetByIDAsync(id);
            if(news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var newsList =await _newsService.GetAllAsync();
            if(newsList == null)
            {
                return NotFound();
            }
            return Ok(newsList);
        }
    }
}
