using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region istatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:7143/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.AuthorCount = values3.authorCount;
                ViewBag.AuthorCountRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.BlockCount = values4.blockCount;
                ViewBag.BlockCountRandom = AuthorCountRandom;
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

            #region istatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:7143/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.AvgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.AvgRentPriceForWeeklyRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:7143/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.AvgRentPriceForMountly = values8.avgRentPriceForMonthly.ToString("0.00");
                ViewBag.AvgRentPriceForMountlyRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik9
            var responseMessage9 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.CarCountByTranmissionIsAuto = values9.carCountByTranmissionIsAuto;
                ViewBag.CarCountByTranmissionIsAutoRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik10
            var responseMessage10 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.CarCountByKmSmallerThen1000 = values10.carCountByKmSmallerThan1000;
                ViewBag.CarCountByKmSmallerThen1000Random = AuthorCountRandom;
            }
            #endregion

            #region istatistik11
            var responseMessage11 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.CarCountByFuelGasolineOrDiesel = values11.carCountByFuelGasolineOrDiesel;
                ViewBag.CarCountByFuelGasolineOrDieselRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik12
            var responseMessage12 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.CarCountByFuelElectric = values12.carCountByFuelElectric;
                ViewBag.CarCountByFuelElectricRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik13
            var responseMessage13 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.CarBrandAndModelByRentPriceDailyMax = values13.carBrandAndModelByRentPriceDailyMax;
                ViewBag.CarBrandAndModelByRentPriceDailyMaxRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik14
            var responseMessage14 = await client.GetAsync("https://localhost:7143/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.CarBrandAndModelByRentPriceDailyMin = values14.carBrandAndModelByRentPriceDailyMin;
                ViewBag.CarBrandAndModelByRentPriceDailyMinRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik15
            var responseMessage15 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.BrandNameByMaxCar = values15.brandNameByMaxCar;
                ViewBag.BrandNameByMaxCarRandom = AuthorCountRandom;
            }
            #endregion

            #region istatistik16
            var responseMessage16 = await client.GetAsync("https://localhost:7143/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int AuthorCountRandom = rnd.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.BlogTitleByMaxBlogComment = values16.blogTitleByMaxBlogComment;
                ViewBag.BlogTitleByMaxBlogCommentRandom = AuthorCountRandom;
            }
            #endregion



            return View();
        }
    }
}
