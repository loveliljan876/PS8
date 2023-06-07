using PS6.Areas.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Interfaces
{
    public interface ILeapYearRepository
    {
        Task Add(YearValidationResult yearValidationResult);
        Task<IQueryable<YearValidationResult>> GetResults(int pageIndex, int pageSize);
    }
}
