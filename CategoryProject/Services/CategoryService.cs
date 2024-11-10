using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CategoryProject.Models;
using SharedLibrary.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace CategoryProject.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(HttpClient httpClient, ILogger<CategoryService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri("http://localhost:5225/");
            _logger = logger;
        }
         public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
        try
        {
            var response = await _httpClient.GetAsync("categories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Data received: {jsonData}", jsonData); // Log response data
                return JsonConvert.DeserializeObject<List<CategoryDto>>(jsonData) ?? new List<CategoryDto>();
            }
            else
            {
                _logger.LogError("Failed to retrieve data: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching categories.");
        }
        return new List<CategoryDto>(); // Return an empty list if response is unsuccessful
        }
    }
}
