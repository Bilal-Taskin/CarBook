using CarBook.Dto.BlockDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class BlockController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public BlockController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Authors Blogs";
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7143/api/Blocks/GetAllBlocksWithAuthorList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlocksWithAuthorDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlockDetail(int id )
        {
            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Blog Detail And Commands";
            ViewBag.blockId = id;
            return View();
        }
    }
}
