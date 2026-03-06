using CarBook.Application.Interfaces.ReviewInterface;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<Review> GetReviewsByCarId(int carId)
        {
          var reviews = _context.Reviews.Where(r => r.CarId == carId).ToList();
          return reviews;
        }
    }
}
