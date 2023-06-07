using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;
using PS6.Interfaces;
using PS6.Pages.Forms;
using PS6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PS6.Services
{
    public class LeapYearImplementation : ILeapYearInterface
    {
        private readonly ILeapYearRepository leapYearRepository;

        public LeapYearImplementation(ILeapYearRepository leapYearRepository)
        {
            this.leapYearRepository = leapYearRepository;
        }

        public async Task<ListLeapYearResultVM> GetResults(int pageIndex, int pageSize)
        {
            var results = await leapYearRepository.GetResults(pageIndex, pageSize);
            var leapYearResultVMList = new List<LeapYearResultVM>();
            foreach (var result in results)
            {
                var resultVM = new LeapYearResultVM
                {
                    Id = result.Id,
                    Year = result.Year,
                    Result = result.Result,
                    TimeAdded = result.TimeAdded,
                    UserId = result.UserId,
                    UserLogin = result.UserLogin,
                };
                leapYearResultVMList.Add(resultVM);
            }

            return new ListLeapYearResultVM {  ListLeapYearResult = leapYearResultVMList};
        }

        public async Task Save(HttpContext httpContext, YearResponse response)
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = httpContext.User.Identity.Name;

            var yearValidationResult = new YearValidationResult
            {
                Year = response.Year,
                Result = response.ToString(),
                TimeAdded = DateTime.Now,
                UserId = userId,
                UserLogin = userName
            };

            await leapYearRepository.Add(yearValidationResult);
        }
    }
}
