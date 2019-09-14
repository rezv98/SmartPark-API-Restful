using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController:ControllerBase
    {
        private IRateService rateService;
        public RateController( IRateService rateService){
            this.rateService=rateService;
        }
         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                rateService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Rate rate)
        {
            return Ok(
                rateService.Save(rate)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Rate rate)
        {
            return Ok(
                rateService.Update(rate)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                rateService.Delete(id)
            );
        }
    }
}