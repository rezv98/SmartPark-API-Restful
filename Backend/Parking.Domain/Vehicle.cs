namespace Parking.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CarPlate{ get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}