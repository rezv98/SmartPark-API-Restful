using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController:ControllerBase
    {
        private IVehicleService vehicleService;
        public VehicleController(IVehicleService vehicleService){
            this.vehicleService=vehicleService;
        }
         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                vehicleService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Vehicle vehicle)
        {
            return Ok(
                vehicleService.Save(vehicle)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Vehicle vehicle)
        {
            return Ok(
                vehicleService.Update(vehicle)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                vehicleService.Delete(id)
            );
        }

    }
}