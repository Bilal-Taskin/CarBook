using CarBook.Dto.BlockDtos;
using CarBook.Dto.CommentDtos;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class BlockController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlockController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.v1 = "Blogs";
            ViewBag.v2 = "Authors Blogs";
            var client = _httpClientFactory.CreateClient();
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

            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7143/api/Comment/GetCommentCountByBlockId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
           // var values2 = JsonConvert.DeserializeObject<GetBlockById>(jsonData2);
            ViewBag.commentCount = jsonData2;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.blockId = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7143/api/Comment/CreateCommentWithMediator", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
