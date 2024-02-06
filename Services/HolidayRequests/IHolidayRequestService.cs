using HolidayRequestsApp.Controllers.HolidayRequests.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Services.HolidayRequests
{
    public interface IHolidayRequestService
    {
        /// <summary>
        /// Get holiday requests list
        /// </summary>
        Task<List<HolidayRequestResponse>> GetHolidayRequestsList();

        /// <summary>
        /// delete holiday request
        /// </summary>
        Task<bool> DeleteHolidayRequest(Guid id);
    }
}
