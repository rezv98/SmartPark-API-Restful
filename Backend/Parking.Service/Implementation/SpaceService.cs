using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class SpaceService : ISpaceService
    {
        private ISpaceRepository spaceRepository;

        public SpaceService(ISpaceRepository spaceRepository) {

            this.spaceRepository = spaceRepository;
        }

        public bool Delete(int id)
        {
            return spaceRepository.Delete(id);
        }

        public Space Get(int id)
        {
            return spaceRepository.Get(id);
        }

        public IEnumerable<Space> GetAll()
        {
            return spaceRepository.GetAll();
        }

        public bool Save(Space entity)
        {
            return spaceRepository.Save(entity);
        }

        public bool Update(Space entity)
        {
            return spaceRepository.Update(entity);
        }
    }
}