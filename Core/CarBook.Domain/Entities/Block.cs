using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Block
    {
        public int BlockID { get; set; }
        public string Title { get; set; }   
        public int AuthorId { get; set; }   
        public Author Author { get; set; }
        public string CoverImageUrl{ get; set; }
        public DateTime CreatedDate{ get; set; }
        public int CategoryId{ get; set; }
        public Category Category{ get; set; }
        public string BlockDescription { get; set; }
        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comment{ get; set; }

    }
}
