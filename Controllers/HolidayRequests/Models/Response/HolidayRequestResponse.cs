﻿using HolidayRequestsApp.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Controllers.HolidayRequests.Models.Response
{
    public class HolidayRequestResponse
    {
        public Guid Id { get; set; }
        public string Collaborator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Observation { get; set; }
        public DateTime RequestDate { get; set; }
        public ValidationStatus Status { get; set; }
    }
}
