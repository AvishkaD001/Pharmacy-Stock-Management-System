using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using PharmacyWebApp.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PharmacyWebApp.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly HttpClient _httpClient;

        public PharmacyController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("PharmacyAPI");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(PharmacyModel pharmacy)
        {
            
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5208/api/pharmacy/login", pharmacy);

            if (response.IsSuccessStatusCode)
            {
               
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>(); 

                if (result != null && result.PharmacyId > 0)
                {
                   
                    HttpContext.Session.SetInt32("PharmacyId", result.PharmacyId);

                    return RedirectToAction("Index", "Stock");
                }
            }

            ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
            return View();
        }

        // GET: BuyDrug
        public IActionResult BuyDrug(int id) 
        {
 
            int? pharmacyId = HttpContext.Session.GetInt32("PharmacyId");

            if (pharmacyId == null)
            {
                return RedirectToAction("Login", "Pharmacy");
            }

       
            var model = new DrugOrderModel
            {
                Pharmacyid = pharmacyId.Value, 
                DrugID = id                
            };

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> BuyDrug(DrugOrderModel drugOrderModel)
        {
            Console.WriteLine("BuyDrug action called."); 

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid."); 
                ViewData["Message"] = "Invalid data. Please check the inputs.";
                return View(drugOrderModel);
            }

            var purchaseRequest = new PurchaseRequest
            {
                PharmacyID = drugOrderModel.Pharmacyid,
                DrugID = drugOrderModel.DrugID,
                Quantity = drugOrderModel.Quantity
            };

            var json = JsonSerializer.Serialize(purchaseRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                Console.WriteLine("Sending request to API...");
                var response = await _httpClient.PostAsync("http://localhost:5208/api/pharmacy/buy", content);

                Console.WriteLine($"Response Status: {response.StatusCode}");
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response Body: {responseString}");

                if (response.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Purchase successful!";
                }
                else
                {
                    ViewData["Message"] = $"Purchase failed. Status: {response.StatusCode}. Details: {responseString}";
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                ViewData["Message"] = "An error occurred while processing your request. Please try again later.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                ViewData["Message"] = "An unexpected error occurred. Please contact support.";
            }

            return View(drugOrderModel);
        }
    }

  
    public class PurchaseRequest
    {
        public int PharmacyID { get; set; }
        public int DrugID { get; set; }
        public int Quantity { get; set; }


    }





}
