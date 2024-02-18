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
        Task RemoveAsync(HolidayRequestDataModel holidayRequest);

        /// <summary>
        /// Save changes
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// Add holiday request
        /// </summary>
        Task AddAsync(HolidayRequestDataModel holiday);

        /// <summary>
        /// Update holiday request
        /// </summary>
        Task Update(HolidayRequestDataModel holiday);
    }
}
