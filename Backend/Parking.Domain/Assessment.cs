namespace Parking.Domain
{
    public class Assessment
    {
        public int Id { get; set; }
        public  int Rate { get; set; }
        public string Comments{ get; set; }
        public int ParkingsId { get; set; }
        public Parkings Parkings { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        
    }
}