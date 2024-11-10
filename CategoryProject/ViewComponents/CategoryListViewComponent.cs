using System;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using CategoryProject.Services;
using System.Threading.Tasks;


namespace CategoryProject.ViewComponents
{
    public class CategoryListViewComponent: ViewComponent
    {
        private readonly CategoryService _categoryService;

        public CategoryListViewComponent(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }
    }
}