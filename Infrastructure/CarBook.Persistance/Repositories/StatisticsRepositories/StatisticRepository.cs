using CarBook.Application.Interfaces.StatistcisInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            //Select Top(1) BlogId,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc 
            var values = _context.Comments.GroupBy(x => x.BlockId).
                              Select(y => new
                              {
                                  BlockId = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogdName = _context.Blocks.Where(x => x.BlockID == values.BlockId).Select(y => y.Title).FirstOrDefault();
            return blogdName;
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = _context.Cars.GroupBy(x => x.BrandID).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;

        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //Select Avg(Amount) from CarPricings where PricingID=(Select PricingID From Pricings Where Name='Günlük')
            var id = _context.Pricings.Where(p => p.Name == "Günlük").Select(p => p.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(cp => cp.PricingId == id).Average(cp => cp.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var id = _context.Pricings.Where(p => p.Name == "Aylık").Select(p => p.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(cp => cp.PricingId == id).Average(cp => cp.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var id = _context.Pricings.Where(p => p.Name == "Haftalık").Select(p => p.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(cp => cp.PricingId == id).Average(cp => cp.Amount);
            return value;
        }

        public int GetBlockCount()
        {
            var value = _context.Blocks.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
        public int GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }
    }
}
