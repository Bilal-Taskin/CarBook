using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingsDtos;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        
        private readonly IHttpClientFactory httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Cars";
            ViewBag.v2 = "Choose Your Car";
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7143/api/CarPricing");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
