using HolidayRequestsApp.Controllers.HolidayRequests.Models.Query;
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
        Task<List<HolidayRequestItemResponse>> GetHolidayRequestsList();

        /// <summary>
        /// Get holiday request by id
        /// </summary>
        Task<HolidayRequestResponse> GetHolidayRequest(Guid id);

        /// <summary>
        /// delete holiday request
        /// </summary>
        Task<bool> DeleteHolidayRequest(Guid id);

        /// <summary>
        /// Create holiday request
        /// </summary>
        Task<HolidayRequestResponse> CreateHolidayRequest(HolidayRequestQuery query);

        /// <summary>
        /// Create holiday request
        /// </summary>
        Task<HolidayRequestResponse> UpdateHolidayRequest(HolidayRequestQuery query);
    }
}
