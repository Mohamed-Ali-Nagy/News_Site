using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_Site.Services.Interfaces;
using News_Site.ViewModels.CategoryVMs;

namespace News_Site.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;
        public CategoryController(ICategoryService categoryService, INewsService newsService)
        {
            _categoryService = categoryService;
            _newsService = newsService;

        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddVM categoryAddVM)
        {
            await _categoryService.AddAsync(categoryAddVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVM);
            }
            if (!await _categoryService.UpdateAsync(categoryVM))
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIDAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryVM categoryVM)
        {

            var hasNews = await _newsService.HasNewsByCategoryAsync(categoryVM.ID);
            if (hasNews)
            {
                ModelState.AddModelError(string.Empty, "You have to delete the news first");
                return View(categoryVM);
            }
            if (!await _categoryService.DeleteAsync(categoryVM.ID))
            {
                return NotFound();
            };
            return RedirectToAction(nameof(Index));
        }

    }
}
