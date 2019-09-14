using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class DriverService : IDriverService
    {
        private IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository) {

            this.driverRepository = driverRepository;
        }

        public bool Delete(int id)
        {
            return driverRepository.Delete(id);
        }

        public Driver Get(int id)
        {
            return driverRepository.Get(id);
        }

        public IEnumerable<Driver> GetAll()
        {
            return driverRepository.GetAll();
        }

        public bool Save(Driver entity)
        {
            return driverRepository.Save(entity);
        }

        public bool Update(Driver entity)
        {
            return driverRepository.Update(entity);
        }
    }
}