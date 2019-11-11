using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    public class SpaceRepository : ISpaceRepository
    {
        private ApplicationDbContext context;
        public SpaceRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
            try
            {
                var space = context.spaces.Single(x => x.Id == id);
                context.Remove(space);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Space Get(int id)
        {
            var result = new Space();
            try
            {
                result = context.spaces.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Space> GetAll()
        {
            var result = new List<Space>();
            try
            {
                result = context.spaces.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Space entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
              
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return true;
        }

        public bool Update(Space entity)
        {
            try{
                
                var space =context.spaces.Single(x => x.Id == entity.Id);
                space.Id = entity.Id;
                space.Tag = entity.Tag;
                space.Available = entity.Available;
                
                context.Update(space);
                context.SaveChanges();

            }catch(System.Exception){
                return false;
            }
            return true;
        }
    }
}