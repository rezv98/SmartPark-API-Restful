using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class DriverRepository : IDriverRepository
    {
        private ApplicationDbContext context;
        public DriverRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var driver = context.drivers.Single(x => x.Id == id);
                context.Remove(driver);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Driver Get(int id)
        {
            var result = new Driver();
            try
            {
                result = context.drivers.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Driver> GetAll()
        {
            var result = new List<Driver>();
            try
            {
                result = context.drivers.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Vehicle> GetVehicles(int id)
        {
            var result= new List<Vehicle>();
            try
            {
                result=context.vehicles.Where(x=>x.DriverId==id).ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Driver entity)
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

        public bool Update(Driver entity)
        {
            try{
                
                var driver =context.drivers.Single(x => x.Id == entity.Id);
                driver.Id = entity.Id;
                driver.FullName = entity.FullName;
                driver.Email = entity.Email;
                driver.Dni=entity.Dni;
                driver.Cellphone=entity.Cellphone;
                
                context.Update(driver);
                context.SaveChanges();

            }catch(System.Exception){
                return false;

            }
            return true;
        }
    }
}