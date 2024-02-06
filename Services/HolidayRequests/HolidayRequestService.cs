using AutoMapper;
using HolidayRequestsApp.Controllers.HolidayRequests.Models.Response;
using HolidayRequestsApp.Infrastructure.Repositories.HolidayRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Services.HolidayRequests
{
    public class HolidayRequestService : IHolidayRequestService
    {
        protected readonly IMapper _mapper;
        private readonly IHolidayRequestRepository _holidayRequestRepository;
        public HolidayRequestService(
            IHolidayRequestRepository holidayRequestRepository,
            IMapper mapper
            ) 
        {
            _holidayRequestRepository = holidayRequestRepository ?? throw new ArgumentNullException(nameof(holidayRequestRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get holiday requests list
        /// </summary>
        public async Task<List<HolidayRequestResponse>> GetHolidayRequestsList()
        {
            var list = await _holidayRequestRepository.GetHolidayRequestsList();
            return _mapper.Map<List<HolidayRequestResponse>>(list);
        }

        /// <summary>
        /// delete holiday request
        /// </summary>
        public async Task<bool> DeleteHolidayRequest(Guid id)
        {
            var holiday = await _holidayRequestRepository.GetHolidayRequest(id);
            if (holiday == null)
            {
                throw new Exception(Constant.ItemNotFound);
            }
            await _holidayRequestRepository.RemoveAsync(holiday);
            await _holidayRequestRepository.SaveChangesAsync();
            return true;
        }
    }
}
