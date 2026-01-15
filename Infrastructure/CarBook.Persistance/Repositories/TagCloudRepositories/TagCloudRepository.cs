using CarBook.Application.Interfaces.TagCloudInterface;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext carBookContext;

        public TagCloudRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = carBookContext.TagClouds.Where(x => x.BlockId == id).ToList();
            return values;
        }
    }
}
