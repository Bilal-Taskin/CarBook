using CarBook.Application.Interfaces.CarDescriptionInterface;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
    public class CarDescriptionRepsoitories : ICarDescriptionRepository
    {
        private readonly CarBookContext _carBookContext;

        public CarDescriptionRepsoitories(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int carId)
        {
            var values = await _carBookContext.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefaultAsync();
            return values;
        }
    }
}
