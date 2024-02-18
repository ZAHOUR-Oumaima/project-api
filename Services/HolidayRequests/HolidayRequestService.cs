using AutoMapper;
using HolidayRequestsApp.Controllers.HolidayRequests.Models.Query;
using HolidayRequestsApp.Controllers.HolidayRequests.Models.Response;
using HolidayRequestsApp.Infrastructure.Data.Enums;
using HolidayRequestsApp.Infrastructure.Data.Models.HolidayRequests;
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
        public async Task<List<HolidayRequestItemResponse>> GetHolidayRequestsList()
        {
            var list = await _holidayRequestRepository.GetHolidayRequestsList();
            return _mapper.Map<List<HolidayRequestItemResponse>>(list);
        }


        /// <summary>
        /// Get holiday request by id
        /// </summary>
        public async Task<HolidayRequestResponse> GetHolidayRequest(Guid id)
        {
            var holiday = await _holidayRequestRepository.GetHolidayRequest(id);
            return _mapper.Map<HolidayRequestResponse>(holiday);
        }

        /// <summary>
        /// Delete holiday request
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

        /// <summary>
        /// Create holiday request
        /// </summary>
        public async Task<HolidayRequestResponse> CreateHolidayRequest(HolidayRequestQuery query)
        {
            var holiday = _mapper.Map<HolidayRequestDataModel>(query);
            holiday.Status = ValidationStatus.AwaitingValidation;

            await _holidayRequestRepository.AddAsync(holiday);
            await _holidayRequestRepository.SaveChangesAsync();
            return _mapper.Map<HolidayRequestResponse>(holiday);
        }

        /// <summary>
        /// Create holiday request
        /// </summary>
        public async Task<HolidayRequestResponse> UpdateHolidayRequest(HolidayRequestQuery query)
        {
            var holiday = _mapper.Map<HolidayRequestDataModel>(query);
            await _holidayRequestRepository.Update(holiday);
            await _holidayRequestRepository.SaveChangesAsync();
            return _mapper.Map<HolidayRequestResponse>(holiday);
        }
    }
}
