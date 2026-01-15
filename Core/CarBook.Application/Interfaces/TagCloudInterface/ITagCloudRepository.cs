using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.TagCloudInterface
{
    public interface ITagCloudRepository
    {
        List<TagCloud> GetTagCloudsByBlogId(int id);
    }
}
