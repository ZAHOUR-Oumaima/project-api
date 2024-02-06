using HolidayRequestsApp.Infrastructure.Data.Models.HolidayRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp.Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

        public DbSet<HolidayRequestDataModel> HolidayRequests { get; set; }
    }
}
