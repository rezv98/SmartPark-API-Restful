using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class ParkingsRepository : IParkingsRepository
    {
        private ApplicationDbContext context;
        public ParkingsRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var parking = context.parkings.Single(x => x.Id == id);
                context.Remove(parking);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Parkings Get(int id)
        {
            var result = new Parkings();
            try
            {
                result = context.parkings.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Parkings> GetAll()
        {
            var result = new List<Parkings>();
            try
            {
                result = context.parkings.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Parkings entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
              
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Update(Parkings entity)
        {
            try{
                
                var parking =context.parkings.Single(x => x.Id == entity.Id);
                parking.Id = entity.Id;
                parking.Name = entity.Name;
                parking.NroSpaces = entity.NroSpaces;
                parking.Address=entity.Address;
                parking.Description=entity.Description;
                parking.Country=entity.Country;
                parking.Cellphone= entity.Cellphone;
                parking.Location=entity.Location;
                parking.Park_Type=entity.Park_Type;
                parking.Photo_Reference=entity.Photo_Reference;
                
                context.Update(parking);
                context.SaveChanges();

            }catch(System.Exception){
                return false;
            }
            return true;
        
        
        }
    }
}