using HolidayRequestsApp.Controllers.HolidayRequests.Models.Query;
using HolidayRequestsApp.Controllers.HolidayRequests.Models.Response;
using HolidayRequestsApp.Services.HolidayRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Controllers.HolidayRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayRequestsController : ControllerBase
    {
        protected readonly IHolidayRequestService _holidayRequestService;

        public HolidayRequestsController(IHolidayRequestService holidayRequestService)
        {
            _holidayRequestService = holidayRequestService ?? throw new ArgumentNullException(nameof(holidayRequestService));
        }

        [HttpGet]
        public async Task<ActionResult<List<HolidayRequestItemResponse>>> GetHolidayRequestsList()
        {
            return Ok(await _holidayRequestService.GetHolidayRequestsList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<HolidayRequestResponse>>> GetHolidayRequestById(Guid id)
        {
            return Ok(await _holidayRequestService.GetHolidayRequest(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteHolidayRequest(Guid id)
        {
            return Ok(await _holidayRequestService.DeleteHolidayRequest(id));
        }

        [HttpPost("Create")]
        public async Task<ActionResult<HolidayRequestResponse>> CreateHolidayRequest(HolidayRequestQuery query)
        {
            return Ok(await _holidayRequestService.CreateHolidayRequest(query));
        }

        [HttpPost("Update")]
        public async Task<ActionResult<HolidayRequestResponse>> UpdateHolidayRequest(HolidayRequestQuery query)
        {
            return Ok(await _holidayRequestService.UpdateHolidayRequest(query));
        }
    }
}
