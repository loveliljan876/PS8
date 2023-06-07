using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;
using PS6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Repositories
{
    public class LeapYearRepository : ILeapYearRepository
    {
        private readonly YearDbContext _context;

        public LeapYearRepository(YearDbContext context)
        { 
            _context = context;
        }

        public async Task<IQueryable<YearValidationResult>> GetResults(int pageIndex, int pageSize)
        {
            return _context.YearValidationResult.AsNoTracking().Skip(pageSize * pageIndex).Take(pageSize);
        }

        public async Task Add(YearValidationResult yearValidationResult)
        {
            _context.YearValidationResult.Add(yearValidationResult);
            await _context.SaveChangesAsync();
        }
    }
}
