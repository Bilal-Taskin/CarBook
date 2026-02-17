using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("GetCarCount")]
        //public async Task<IActionResult> GetCarCount()
        //{
        //    var values = await _mediator.Send(new GetCarCountQuery());
        //    return Ok(values);
        //}

        //[HttpGet("GetAuthorCount")]
        //public async Task<IActionResult> GetAuthorCount()
        //{
        //    var values = await _mediator.Send(new GetAuthorCountQuery());
        //    return Ok(values);
        //}

        //[HttpGet("GetBlockCount")]
        //public async Task<IActionResult> GetBlockCount()
        //{
        //    var values = await _mediator.Send(new GetBlockCountQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetLocationCount")]
        //public IActionResult GetLocationCount()
        //{
        //    var values = mediator.Send(new GetLocationCountQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetBrandCount")]
        //public IActionResult GetBrandCount()
        //{
        //    var values = mediator.Send(new GetBrandCountQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetAvgRentPriceForDaily")]
        //public IActionResult GetAvgRentPriceForDaily()
        //{
        //    var values = mediator.Send(new GetAvgRentPriceForDailyQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetAvgRentPriceForWeekly")]
        //public IActionResult GetAvgRentPriceForWeekly()
        //{
        //    var values = mediator.Send(new GetAvgRentPriceForWeeklyQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetAvgRentPriceForMonthly")]
        //public IActionResult GetAvgRentPriceForMonthly()
        //{
        //    var values = mediator.Send(new GetAvgRentPriceForMonthlyQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetBrandNameByMaxCar")]
        //public IActionResult GetBrandNameByMaxCar()
        //{
        //    var values = mediator.Send(new GetBrandNameByMaxCarQuery()).Result;
        //    return Ok(values);
        //}

        //[HttpGet("GetBlogTitleByMaxBlogComment")]
        //public IActionResult GetBlogTitleByMaxBlogComment()
        //{
        //    var values = mediator.Send(new GetBlogTitleByMaxBlogCommentQuery()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarCountByKmSmallerThan1000")]
        //public IActionResult GetCarCountByKmSmallerThan1000()
        //{
        //    var values = mediator.Send(new GetCarCountByKmSmallerThan1000Query()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        //public IActionResult GetCarCountByFuelGasolineOrDiesel()
        //{
        //    var values = mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarCountByFuelElectric")]
        //public IActionResult GetCarCountByFuelElectric()
        //{
        //    var values = mediator.Send(new GetCarCountByFuelElectricQuery()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarCountByTranmissionIsAuto")]
        //public IActionResult GetCarCountByTranmissionIsAuto()
        //{
        //    var values = mediator.Send(new GetCarCountByTranmissionIsAutoQuery()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        //public IActionResult GetCarBrandAndModelByRentPriceDailyMax()
        //{
        //    var values = mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery()).Result;
        //    return Ok(values);
        //}


        //[HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        //public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        //{
        //    var values =  mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery()).Result;
        //    return Ok(values);
        //}

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlockCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var values = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFuelElectric")]
        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(values);
        }



    }
}
