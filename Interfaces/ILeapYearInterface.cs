using PS6.Areas.Data.Models;
using PS6.Pages.Forms;
using PS6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Areas.Data
{
    public interface ILeapYearInterface
    {
        Task Save(HttpContext httpContext, YearResponse yearResponse);
        Task<ListLeapYearResultVM> GetResults(int pageIndex, int pageSize);
    }
}
