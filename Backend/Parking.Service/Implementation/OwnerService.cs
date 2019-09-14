using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository) {

            this.ownerRepository = ownerRepository;
        }

        public bool Delete(int id)
        {
            return ownerRepository.Delete(id);
        }

        public Owner Get(int id)
        {
            return ownerRepository.Get(id);
        }

        public IEnumerable<Owner> GetAll()
        {
            return ownerRepository.GetAll();
        }

        public bool Save(Owner entity)
        {
            return ownerRepository.Save(entity);
        }

        public bool Update(Owner entity)
        {
            return ownerRepository.Update(entity);
        }
    }
}