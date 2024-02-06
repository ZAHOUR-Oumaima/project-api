using AutoMapper;
using HolidayRequestsApp.Controllers.HolidayRequests.Models.Response;
using HolidayRequestsApp.Infrastructure.Data.Models.HolidayRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Holiday requests
            CreateMap<HolidayRequestDataModel, HolidayRequestResponse>();
            #endregion
        }
    }
}
