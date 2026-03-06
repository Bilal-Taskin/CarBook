using CarBook.Dto.CarPricingsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboradCarPricingListComponentPratial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _AdminDashboradCarPricingListComponentPratial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = "Packets";
            ViewBag.v2 = "Car Price Packets";
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7143/api/CarPricing/GetCarPricingWithTimePeriodQueryList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
