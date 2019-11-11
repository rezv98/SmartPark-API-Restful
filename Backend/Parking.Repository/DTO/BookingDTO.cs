using System;

namespace Parking.Repository.DTO
{
    public class BookingDTO
    {
         public int Id { get; set; }
        public DateTime ArrivingTime {get; set;}
        public int Status { get; set; }
        public int VehicleId { get; set; }

        public string carplate {get;set;}

        
        public string spaceTag{get;set;}
        public int SpaceId { get; set; }
    }
}