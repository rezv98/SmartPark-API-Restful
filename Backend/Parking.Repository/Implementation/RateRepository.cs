using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class RateRepository : IRateRepository
    {
        private ApplicationDbContext context;
        public RateRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var rates = context.rates.Single(x => x.Id == id);
                context.Remove(rates);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Rate Get(int id)
        {
            var result = new Rate();
            try
            {
                result = context.rates.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Rate> GetAll()
        {
            var result = new List<Rate>();
            try
            {
                result = context.rates.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Rate entity)
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

        public bool Update(Rate entity)
        {
           try{
                
                var rate =context.rates.Single(x => x.Id == entity.Id);
                rate.Id = entity.Id;
                rate.Veh_Type = entity.Veh_Type;
                rate.Price = entity.Price;
                rate.Frecuency=entity.Frecuency;
                
                context.Update(rate);
                context.SaveChanges();

            }catch(System.Exception){
                return false;
            }
            return true;
        }
    }
}