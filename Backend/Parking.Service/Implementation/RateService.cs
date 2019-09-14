using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class RateService : IRateService
    {
        private IRateRepository rateRepository;

        public RateService(IRateRepository rateRepository) {

            this.rateRepository = rateRepository;
        }

        public bool Delete(int id)
        {
            return rateRepository.Delete(id);
        }

        public Rate Get(int id)
        {
            return rateRepository.Get(id);
        }

        public IEnumerable<Rate> GetAll()
        {
            return rateRepository.GetAll();
        }

        public bool Save(Rate entity)
        {
            return rateRepository.Save(entity);
        }

        public bool Update(Rate entity)
        {
            return rateRepository.Update(entity);
        }
    }
}