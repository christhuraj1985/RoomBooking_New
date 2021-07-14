using RoomBookingAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingAPI.Services
{
    public class RoomBookingDatabaseSettings : IRoomBookingDatabaseSettings
    {
        public string RoomBookingCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
