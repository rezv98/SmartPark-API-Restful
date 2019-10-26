using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/owners)]
    [ApiController]
    public class OwnerController:ControllerBase
    {
        private IOwnerService ownerService;
        public OwnerController(IOwnerService ownerService){
            this.ownerService=ownerService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                ownerService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Owner owner)
        {
            return Ok(
                ownerService.Save(owner)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Owner owner)
        {
            return Ok(
                ownerService.Update(owner)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                ownerService.Delete(id)
            );
        }
    }
}