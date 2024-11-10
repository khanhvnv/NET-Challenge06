using System;
using System.Collections.Generic;
using SharedLibrary.Models;

namespace CategoryProject.Models
{
    public class HomeViewModel
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public List<ProductDto> FeaturedProducts { get; set; } = new List<ProductDto>();

    }
}