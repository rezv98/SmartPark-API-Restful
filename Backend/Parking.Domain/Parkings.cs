namespace Parking.Domain
{
    public class Parkings
    {
         
        public int Id { get; set; }
        public string Name { get; set; }
        public int NroSpaces { get; set; }
        public string Address { get; set; }
        public string Description {get;set;}
        public string Country {get;set;}
        public string Cellphone { get; set; }
        public string Location { get; set; }
        public string Park_Type {get; set;}
        public string Photo_Reference{get ; set;}
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

      

        
    }
}