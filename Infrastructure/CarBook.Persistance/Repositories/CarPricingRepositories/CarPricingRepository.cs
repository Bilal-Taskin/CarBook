using CarBook.Application.Features.ViewModels;
using CarBook.Application.Interfaces.CarPricingInterface;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }



        public List<CarPricing> GetCarPricingWithTimePeriod()
        {

            throw new NotImplementedException();
            //List<CarPricing> values = new List<CarPricing>();
            //using (var command = _context.Database.GetDbConnection().CreateCommand())
            //{
            //    command.CommandText = "Select * from (Select  Brands.Name, PricingId, Amount From CarPricings Inner Join Cars On Cars.CarID =CarPricings.CarID Inner Join  Brands On Brands.BrandID = Cars.BrandID ) As SourceTable Pivot ( Sum(Amount) for PricingId In([3],[6],[4]) )As PivotTable;";
            //    command.CommandType = System.Data.CommandType.Text;
            //    _context.Database.OpenConnection();
            //    using (var reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            CarPricing carPricing = new CarPricing();
            //            Enumerable.Range(1, 3).ToList().ForEach(x =>
            //            {
            //                if (DBNull.Value.Equals(reader[x]))
            //                {
            //                    carPricing.
            //                }
            //                else
            //                {
            //                    carPricing.Amount
            //                }
            //            });
            //            values.Add(carPricing);
            //        }


            //    }
            //    _context.Database.CloseConnection();
            //    return values;



            //}
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * from (Select Model,CoverImageUrl, PricingId, Amount From CarPricings Inner Join Cars On Cars.CarID =CarPricings.CarID Inner Join  Brands On Brands.BrandID = Cars.BrandID ) As SourceTable Pivot ( Sum(Amount) for PricingId In([3],[6],[4]) )As PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>()
                            {
                                Convert.ToDecimal(reader["3"] == DBNull.Value ? 0 : reader["3"]),
                                Convert.ToDecimal(reader["6"] == DBNull.Value ? 0 : reader["6"]),
                                Convert.ToDecimal(reader["4"] == DBNull.Value ? 0 : reader["4"])
                            }

                        };
                        values.Add(carPricingViewModel);


                    }


                }
                _context.Database.CloseConnection();
                return values;



            }
        }

        public List<CarPricing> GetCarsPricingsWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(x => x.PricingId == 2).ToList();
            return values;
        }
    }
}
