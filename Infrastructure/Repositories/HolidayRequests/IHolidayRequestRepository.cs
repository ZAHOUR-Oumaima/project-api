using HolidayRequestsApp.Infrastructure.Data.Models.HolidayRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Infrastructure.Repositories.HolidayRequests
{
    public interface IHolidayRequestRepository
    {
        /// <summary>
        /// Get holiday requests list
        /// </summary>
        Task<IQueryable<HolidayRequestDataModel>> GetHolidayRequestsList();

        /// <summary>
        /// Get holiday request by id
        /// </summary>
        Task<HolidayRequestDataModel> GetHolidayRequest(Guid id);

        /// <summary>
        /// delete holiday request
        /// </summary>
        /// <param name="holidayRequest"></param>
        /// <returns></returns>
        Task RemoveAsync(HolidayRequestDataModel holidayRequest);

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
