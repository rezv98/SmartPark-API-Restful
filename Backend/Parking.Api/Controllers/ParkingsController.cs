using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController:ControllerBase
    {
        private IParkingsService parkingsService;
        public ParkingsController(IParkingsService parkingsService){
            this.parkingsService=parkingsService;
        }
         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                parkingsService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Parkings parking)
        {
            return Ok(
                parkingsService.Save(parking)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Parkings parking)
        {
            return Ok(
                parkingsService.Update(parking)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                parkingsService.Delete(id)
            );
        }
    }
}