using System.Collections.Generic;
using Parking.Domain;

namespace Parking.Service
{
    public interface IDriverService :IService<Driver>
    {
         IEnumerable<Vehicle> GetVehicles(int id);
    }
}