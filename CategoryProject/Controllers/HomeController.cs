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
                new ProductDto { Id = 1, Name = "iPhone 16 Pro", Description = $"Your new iPhone 16 Pro.\n iOS 18. Customize. Stylize. Mesmerize.\n Just the way you want it.", Price = 999.00M, Images = "/images/iphone16Pro.jpg", CreatedDate = new DateOnly(2024,11,08) },
                new ProductDto { Id = 2, Name = "MacBook Pro", Description = $"Designed with the earth in mind", Price = 1599.00M, Images = "/images/macbookPro.jpg", CreatedDate = new DateOnly(2024,11,08) },
                new ProductDto { Id = 2, Name = "iPad Mini", Description = $"The full iPad experience in an ultraportable design.", Price = 499.00M, Images = "/images/iPadMini.jpg", CreatedDate = new DateOnly(2024,11,08) },
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}