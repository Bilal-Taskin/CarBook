using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlockInterface
{
    public interface IBlockRepository
    {
        public List<Block> GetLAst3BlockWithAuthor();
        public List<Block> GetAllBlocksWithAuthor();
    }
}
