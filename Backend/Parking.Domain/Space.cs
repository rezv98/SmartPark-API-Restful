namespace Parking.Domain
{
    public class Space
    {
        public int Id { get; set; }
        public string Tag{ get; set; }
        public bool Available{get; set;}
        public int ParkingsId { get; set; }
        public Parkings Parkings { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}