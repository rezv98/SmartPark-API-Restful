using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class OwnerRepository : IOwnerRepository
    {
        private ApplicationDbContext context;
        public OwnerRepository(ApplicationDbContext context) {

            this.context = context;
        }


        public bool Delete(int id)
        {
             try
            {
                var owner = context.owners.Single(x => x.Id == id);
                context.Remove(owner);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Owner Get(int id)
        {
            var result = new Owner();
            try
            {
                result = context.owners.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Owner> GetAll()
        {
            var result = new List<Owner>();
            try
            {
                result = context.owners.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Owner entity)
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

        public bool Update(Owner entity)
        {
            try{
                
                var owner =context.owners.Single(x => x.Id == entity.Id);
                owner.Id = entity.Id;
                owner.FullName = entity.FullName;
                owner.Email = entity.Email;
                owner.DNI=entity.DNI;
                owner.Cellphone=entity.Cellphone;
                owner.CompanyName=entity.CompanyName;
                owner.RUC= entity.RUC;
                
                context.Update(owner);
                context.SaveChanges();

            }catch(System.Exception){
                return false;

            }
            return true;
        }
    }
}