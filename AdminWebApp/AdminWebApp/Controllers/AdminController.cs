using AdminWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdminWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public AdminController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["ApiBaseUrl"];
        }

        //  Add Pharmacy Page
        public IActionResult AddPharmacy()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> AddPharmacy(Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
                return View(pharmacy);

            var json = JsonConvert.SerializeObject(pharmacy);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/add-pharmacy", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Success");

            ViewBag.ErrorMessage = "Error adding pharmacy!";
            return View(pharmacy);
        }

        // Add Supplier Page
        public IActionResult AddSupplier()
        {
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
                return View(supplier);

            var json = JsonConvert.SerializeObject(supplier);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/add-supplier", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Success");

            ViewBag.ErrorMessage = "Error adding supplier!";
            return View(supplier);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
