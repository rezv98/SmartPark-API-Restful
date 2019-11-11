using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class VehicleRepository : IVehicleRepository
    {
        private ApplicationDbContext context;
        public VehicleRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var vehicle = context.vehicles.Single(x => x.Id == id);
                context.Remove(vehicle);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Vehicle Get(int id)
        {
            var result = new Vehicle();
            try
            {
                result = context.vehicles.Include(x=>x.Driver).Single(x=>x.Id==id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Vehicle> GetAll()
        {
            var result = new List<Vehicle>();
            try
            {
                result = context.vehicles.Include(x=>x.Driver).ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Vehicle entity)
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
                
        public bool Update(Vehicle entity)
        {
            try{
                
                var vehicle =context.vehicles.Single(x => x.Id == entity.Id);
                vehicle.Id = entity.Id;
                vehicle.Type = entity.Type;
                vehicle.CarPlate = entity.CarPlate;
                
                context.Update(vehicle);
                context.SaveChanges();

            }catch(System.Exception){
                return false;
            }
            return true;
        }
    }
}