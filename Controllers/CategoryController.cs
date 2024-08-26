using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using todolist.Data;
using todolist.Models;

namespace todolist.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(IConfiguration configuration)
        {
            _repository = new CategoryRepository(configuration.GetConnectionString("DefaultConnection"));
        }

        
        public IActionResult ViewCategories()
        {
            var categories = _repository.GetAllCategories();
            return View(categories);  
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCategory(category.Name);
                return RedirectToAction(nameof(ViewCategories));
            }
            return View(category);
        }

        public IActionResult EditCategory(int id)
        {
            var categoryName = _repository.GetCategoryNameById(id);
            if (categoryName == null)
            {
                return NotFound();
            }
            var category = new Category { Id = id, Name = categoryName };
            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateCategory(category);
                return RedirectToAction("ViewCategories");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
            return RedirectToAction("ViewCategories");
        }
    }
}
