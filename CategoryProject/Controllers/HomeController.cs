using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CategoryProject.Models;
using CategoryProject.Services;
using System.Collections.Generic;
using SharedLibrary.Models;
using Microsoft.Extensions.Logging;

namespace CategoryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryService _categoryService;
        public HomeController(ILogger<HomeController> logger, CategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            // Hard-coded data for Featured Products
            var featuredProducts = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Bánh kem nhân dâu", Description = $"Như 1 trái dâu tươi đỏ mọng", Price = 335.000M, Images = "/images/Banh-Kem-Dau-1.jpg", CreatedDate = new DateOnly(2024,11,08) },
                new ProductDto { Id = 2, Name = "Bánh quy bơ đậu phộng", Description = $"Thơm ngon giòn béo", Price = 25.000M, Images = "/images/Quy-Bo-Dau-Phong-2.jpg", CreatedDate = new DateOnly(2024,11,08) },
                new ProductDto { Id = 2, Name = "Bánh Flan", Description = $"Núng nính tan mềm trên đầu lưỡi", Price = 12.000M, Images = "/images/Banh-Flan-2.jpg", CreatedDate = new DateOnly(2024,11,08) },
            };

            var model = new HomeViewModel
            {
                Categories = categories,
                FeaturedProducts = featuredProducts
            };

            return View(model);
        }
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return PartialView("_CategoryList", categories);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}