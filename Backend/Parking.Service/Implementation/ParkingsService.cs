using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class ParkingsService : IParkingsService
    {

        private IParkingsRepository parkingRepository;

        public ParkingsService(IParkingsRepository parkingRepository) {

            this.parkingRepository = parkingRepository;
        }

        public bool Delete(int id)
        {
            return parkingRepository.Delete(id);
        }

        public Parkings Get(int id)
        {
            return parkingRepository.Get(id);
        }

        public IEnumerable<Parkings> GetAll()
        {
            return parkingRepository.GetAll();
        }

        public bool Save(Parkings entity)
        {
            return parkingRepository.Save(entity);
        }

        public bool Update(Parkings entity)
        {
            return parkingRepository.Update(entity);
        }
    }
}