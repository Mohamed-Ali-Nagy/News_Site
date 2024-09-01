using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News_Site.Services.Interfaces;
using News_Site.ViewModels.NewsVMs;

namespace News_Site.Controllers
{
    public class NewsController : Controller
    {
        private INewsService _newsService;
        private ICategoryService _categoryService;
        public NewsController(INewsService newsService, ICategoryService categoryService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "ID", "Name",id);
            var news = await _newsService.GetByCategoryIDyAsync(id);
            return View(news);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Add()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "ID", "Name");
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(NewsAddVM newsAddVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "ID", "Name");
                return View(newsAddVM);
            }

            await _newsService.AddAsync(newsAddVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "ID", "Name");

            NewsUpdateVM newsUpdateVM = await _newsService.GetByIDAsync(id);

            if (newsUpdateVM == null)
            {
                return NotFound();
            }
            return View(newsUpdateVM);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(NewsUpdateVM newsUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "ID", "Name");
                return View(newsUpdateVM);
            }
            if (!await _newsService.UpdateAsync(newsUpdateVM))
            {
                return View(newsUpdateVM);
            };
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           if(! await _newsService.DeleteAsync(id))
            {
                return NotFound();
            };
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int id)
        {
            var news = await _newsService.GetDetailsAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

    }
}
