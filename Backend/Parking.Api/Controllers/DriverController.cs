using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController:ControllerBase
    {
        private IDriverService driverService;
        public DriverController(IDriverService driverService){
            this.driverService=driverService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                driverService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Driver driver)
        {
            return Ok(
                driverService.Save(driver)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Driver driver)
        {
            return Ok(
                driverService.Update(driver)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                driverService.Delete(id)
            );
        }
    }
}