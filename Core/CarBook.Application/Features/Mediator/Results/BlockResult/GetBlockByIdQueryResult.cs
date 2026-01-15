using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.BlockResult
{
    public class GetBlockByIdQueryResult
    {
        public int BlockID { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string BlockDescription { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
