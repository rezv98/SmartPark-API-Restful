using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/spaces")]
    [ApiController]
    public class SpaceController:ControllerBase
    {
        private ISpaceService spaceService;
        public SpaceController( ISpaceService spaceService){
            this.spaceService=spaceService;
        }
         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                spaceService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Space space)
        {
            return Ok(
                spaceService.Save(space)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Space space)
        {
            return Ok(
                spaceService.Update(space)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                spaceService.Delete(id)
            );
        }
    }
}