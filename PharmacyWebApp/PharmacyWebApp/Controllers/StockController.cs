using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyWebApp.Controllers
{
    public class StockController : Controller
    {
        private readonly HttpClient _httpClient;

        public StockController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("PharmacyAPI");
        }

        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                var stocks = await _httpClient.GetFromJsonAsync<List<StockModel>>("http://localhost:5208/api/pharmacy/all");
                if (!string.IsNullOrEmpty(searchString))
                {
                    stocks = stocks.Where(s => s.DrugName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                return View(stocks);
            }
            catch (HttpRequestException ex)
            {
          
                ModelState.AddModelError(string.Empty, "Unable to retrieve stock data. Please try again later.");
                return View(new List<StockModel>());
            }
        }
    }
}