using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
             
            var locationid = TempData["locationid"];

            //filterRentACarDto.locationId = int.Parse(locationid.ToString());
            //filterRentACarDto.avaliable = true;

            id = int.Parse(locationid.ToString());

           
            ViewBag.locationid = locationid;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7143/api/RentACars?locationid={id}&available=true");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(result);
            }

            return View();


        }
    }
}
