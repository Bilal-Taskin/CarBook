using CarBook.Dto.BlockDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlock")]
    public class AdminBlockController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBlockController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7143/api/Blocks/GetAllBlocksWithAuthorList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultAllBlocksWithAuthorDto>>(jsonData);
                return View(result);
            }

            return View();
        }


        [Route("RemoveBlock/{id}")]
        public async Task<IActionResult> RemoveBlock(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7143/api/Blocks?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


       
    }
}
