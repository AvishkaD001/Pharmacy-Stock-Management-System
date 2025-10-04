using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SupplierWebApp.Models;
using System;
using Microsoft.Extensions.Logging;

public class SupplierController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SupplierController> _logger;

    public SupplierController(HttpClient httpClient, ILogger<SupplierController> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

   
    [HttpPost]
    public async Task<IActionResult> Register(SupplierRegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5208/api/supplier/register", data);
            var responseBody = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("API Response: " + responseBody);  

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                if (apiResponse != null)
                {
                    TempData["SuccessMessage"] = "Supplier Successfully Registered!";
                    return RedirectToAction("Login", "Supplier");
                }
            }
            else
            {
                _logger.LogError("Registration failed with status code: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during registration");
        }

        ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
        return View(model);
    }

  
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(SupplierLoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5208/api/supplier/login", data);
            var responseBody = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("API Response: " + responseBody);  

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

                if (apiResponse != null)
                {
                    HttpContext.Session.SetInt32("SupplierId", apiResponse.SupplierId);

                    return RedirectToAction("SendTender", "Supplier");
                }
            }
            else
            {
                _logger.LogError("Login failed with status code: {StatusCode}", response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login");
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password.");
        return View(model);
    }

    [HttpGet]
    public IActionResult SendTender()
    {

        if (HttpContext.Session.GetInt32("SupplierId") == null)
        {
            return RedirectToAction("Login", "Supplier");
        }

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> SendTender(TenderRequest tenderRequest)
    {
       
        if (HttpContext.Session.GetInt32("SupplierId") == null)
        {
            return RedirectToAction("Login", "Supplier");
        }

        if (ModelState.IsValid)
        {
            try
            {
             
                var jsonContent = JsonSerializer.Serialize(tenderRequest);

               
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    
                var response = await _httpClient.PostAsync("http://localhost:5208/api/supplier/send-tender", content);

  
                if (response.IsSuccessStatusCode)
                {

                    ViewBag.Message = "Tender Proposal Sent Successfully!";
                }
                else
                {
     
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ViewBag.Message = $"An error occurred: {errorMessage}";
                    _logger.LogError("Tender submission failed with status code: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during tender submission");
                ViewBag.Message = "An error occurred while submitting the tender.";
            }
        }

        return View(tenderRequest);
    }

    public class TenderRequest
    {
        public string CompanyRegistrationId { get; set; }  
        public string TenderDetails { get; set; }          
    }

    public class ApiResponse
    {
        public int SupplierId { get; set; }
        public string Message { get; set; }
    }
}