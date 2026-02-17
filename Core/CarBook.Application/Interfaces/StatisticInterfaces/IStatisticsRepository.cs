using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatistcisInterfaces
{
    public interface IStatisticsRepository       
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlockCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMonthly();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaxBlogComment();
        int GetCarCountByKmSmallerThan1000(); 
        int GetCarCountByFuelGasolineOrDiesel(); 
        int GetCarCountByFuelElectric();
        int GetCarCountByTranmissionIsAuto();
        string GetCarBrandAndModelByRentPriceDailyMax(); 
        string GetCarBrandAndModelByRentPriceDailyMin(); 
    }
}
