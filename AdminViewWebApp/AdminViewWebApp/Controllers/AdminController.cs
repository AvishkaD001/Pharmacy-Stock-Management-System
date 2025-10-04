using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AdminViewWebApp.Models;

namespace AdminviewWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "http://localhost:5208"; 

        public AdminController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // display all drug orders
        public async Task<IActionResult> ViewDrugOrders()
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/api/admin/view-drug-orders");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var drugOrders = JsonConvert.DeserializeObject<List<DrugOrder>>(JsonConvert.DeserializeObject<dynamic>(content).data.ToString());
                return View(drugOrders);
            }
            return View(new List<DrugOrder>());
        }

        //  display all tenders
        public async Task<IActionResult> ViewTenders()
        {
            var response = await _httpClient.GetAsync($"{ApiBaseUrl}/api/admin/view-tenders");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tenders = JsonConvert.DeserializeObject<List<Tender>>(JsonConvert.DeserializeObject<dynamic>(content).data.ToString());
                return View(tenders);
            }
            return View(new List<Tender>());
        }
    }
}