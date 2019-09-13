using System;
namespace Parking.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime ArrivingTime {get; set;}
        public int Status { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int SpaceId { get; set; }
        public Space Space { get; set; }
    }
}