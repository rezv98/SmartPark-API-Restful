using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository) {
            this.vehicleRepository = vehicleRepository;
        }

        public bool Delete(int id)
        {
            return vehicleRepository.Delete(id);
        }

        public Vehicle Get(int id)
        {
            return vehicleRepository.Get(id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return vehicleRepository.GetAll();
        }

        public bool Save(Vehicle entity)
        {
            return vehicleRepository.Save(entity);
        }

        public bool Update(Vehicle entity)
        {
            return vehicleRepository.Update(entity);
        }
    }
}