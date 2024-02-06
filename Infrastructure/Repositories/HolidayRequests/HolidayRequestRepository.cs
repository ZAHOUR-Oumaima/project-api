using HolidayRequestsApp.Infrastructure.Data;
using HolidayRequestsApp.Infrastructure.Data.Models.HolidayRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Infrastructure.Repositories.HolidayRequests
{
    public class HolidayRequestRepository : IHolidayRequestRepository
    {
        protected readonly DataBaseContext _context;
        public HolidayRequestRepository(DataBaseContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Get holiday requests list
        /// </summary>
        public virtual async Task<IQueryable<HolidayRequestDataModel>> GetHolidayRequestsList()
        {
            return _context.HolidayRequests
                .AsQueryable();
        }

        /// <summary>
        /// Get holiday request by id
        /// </summary>
        public virtual async Task<HolidayRequestDataModel> GetHolidayRequest(Guid id)
        {
            return await _context.HolidayRequests
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        /// <summary>
        /// delete holiday request
        /// </summary>
        /// <param name="holidayRequest"></param>
        /// <returns></returns>
        public virtual Task RemoveAsync(HolidayRequestDataModel holidayRequest)
        {
            _context.HolidayRequests.Remove(holidayRequest);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
