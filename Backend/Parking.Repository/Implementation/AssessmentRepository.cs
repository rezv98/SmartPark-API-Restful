using System.Collections.Generic;
using System.Linq;
using Parking.Domain;
using Parking.Repository.Context;

namespace Parking.Repository.Implementation
{
    
    public class AssessmentRepository : IAssessmentRepository
    {
        private ApplicationDbContext context;
         public AssessmentRepository(ApplicationDbContext context) {

            this.context = context;
        }

        public bool Delete(int id)
        {
           try
            {
                var cajero = context.assessments.Single(x => x.Id == id);
                context.Remove(cajero);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Assessment Get(int id)
        {
            var result = new Assessment();
            try
            {
                result = context.assessments.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Assessment> GetAll()
        {
            var result = new List<Assessment>();
            try
            {
                result = context.assessments.ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Assessment entity)
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

        public bool Update(Assessment entity)
        {
            try{
                
                var assessment =context.assessments.Single(x => x.Id == entity.Id);
                assessment.Id = entity.Id;
                assessment.Rate = entity.Rate;
                assessment.Comments = entity.Comments;

                context.Update(assessment);
                context.SaveChanges();

            }catch(System.Exception){
                return false;

            }
            return true;
        }
    }
}