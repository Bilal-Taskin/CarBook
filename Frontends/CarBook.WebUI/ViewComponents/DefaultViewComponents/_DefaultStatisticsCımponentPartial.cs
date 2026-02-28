using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsCımponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultStatisticsCımponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            
            #region istatistik1
            var responseMessage = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
             
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
              
            }
            #endregion

            #region istatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:7143/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LocationCount = values2.LocationCount;
                
            }
            #endregion

            #region istatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
              
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.BrandCount = values3.brandCount;
                
            }
            #endregion

            #region istatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage4.IsSuccessStatusCode)
            {
                
                var jsonData4= await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.CarCountByFuelElectric = values4.carCountByFuelElectric;
                
            }
            #endregion

            return View();
        }
    }
}
