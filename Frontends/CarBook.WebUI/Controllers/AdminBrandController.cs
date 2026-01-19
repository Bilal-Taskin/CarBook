using CarBook.Dto.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
       
            private readonly IHttpClientFactory _httpClientFactory;

            public AdminBrandController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7143/api/Brand");

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                    return View(result);
                }

                return View();
            }

            [HttpGet]
            public IActionResult CreateBrand()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createBrandDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var respondeMessage = await client.PostAsync("https://localhost:7143/api/Brand", stringContent);
                if (respondeMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }


            public async Task<IActionResult> RemoveBrand(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"https://localhost:7143/api/Brand?id="+id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> UpdateBrand(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7143/api/Brand/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                    return View(values);
                }

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDtos)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateBrandDtos);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7143/api/Brand", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }


                return View();
            }
        }
}
