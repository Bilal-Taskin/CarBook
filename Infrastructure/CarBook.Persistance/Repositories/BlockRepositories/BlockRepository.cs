using CarBook.Application.Interfaces.BlockInterface;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.BlockRepositories
{
    //burası interface den gelen metotların içini doldurmak için oluşturduk
    public class BlockRepository : IBlockRepository
    {
        private readonly CarBookContext _context;

        public BlockRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Block> GetAllBlocksWithAuthor()
        {
            var values = _context.Blocks.Include(x=>x.Author).ToList();
            return values;
        }

        public List<Block> GetBlocksByAuthorId(int id)
        {
            var values = _context.Blocks.Include(x=>x.Author).Where(x => x.BlockID == id).ToList();
            return values;
        }

        public List<Block> GetLAst3BlockWithAuthor()
        {
           Task<List<Block>> blocks = _context.Blocks.Include(x => x.Author).OrderByDescending(x => x.BlockID).Take(3).ToListAsync();
            return blocks.Result;

        }
    }
}
