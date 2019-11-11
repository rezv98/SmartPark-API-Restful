using Parking.Domain;
using System.Collections.Generic;
namespace Parking.Repository
{
    public interface IDriverRepository:IRepository<Driver>
    {
        IEnumerable<Vehicle> GetVehicles(int id);
    }
}