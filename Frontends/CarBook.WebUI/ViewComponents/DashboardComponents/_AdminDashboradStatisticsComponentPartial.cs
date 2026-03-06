using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboradStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboradStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random rnd = new Random();
            var client = _httpClientFactory.CreateClient();

            #region istatistik1
            var responseMessage = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = rnd.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = v1;
            }
            #endregion

            #region istatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7143/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationContRandom = rnd.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.LocationCount;
                ViewBag.locationContRandom = locationContRandom;
            }
            #endregion

            #region istatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.brandCount;
                ViewBag.BrandCountRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:7143/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.AvgRentPriceForDaily = values6.avgRentPriceForDaily.ToString("0.00");
                ViewBag.AvgRentPriceForDailyRandom = AuthorCountRandom;
            }
            #endregion

            
             return View();
        }
    }
}
