using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class AssessmentService : IAssessmentService
    {
        private IAssessmentRepository assessmentRepository;

        public AssessmentService(IAssessmentRepository assessmentRepository) {

            this.assessmentRepository=assessmentRepository;
        }

        public bool Delete(int id)
        {
            return assessmentRepository.Delete(id);
        }

        public Assessment Get(int id)
        {
            return assessmentRepository.Get(id);
        }

        public IEnumerable<Assessment> GetAll()
        {
            return assessmentRepository.GetAll();
        }

        public bool Save(Assessment entity)
        {
            return assessmentRepository.Save(entity);
        }

        public bool Update(Assessment entity)
        {
            
            return assessmentRepository.Update(entity);
        }
    }
}