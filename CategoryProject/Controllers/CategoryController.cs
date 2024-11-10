using Microsoft.AspNetCore.Mvc;
using CategoryProject.Models;
using CategoryProject.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CategoryProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }        
    }
}
