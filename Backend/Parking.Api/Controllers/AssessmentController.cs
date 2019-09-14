using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;

namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController:ControllerBase
    {
        private IAssessmentService assessmentService;
        public AssessmentController(IAssessmentService assessmentService){
            this.assessmentService=assessmentService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                assessmentService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Assessment assessment)
        {
            return Ok(
                assessmentService.Save(assessment)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Assessment assessment)
        {
            return Ok(
                assessmentService.Update(assessment)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                assessmentService.Delete(id)
            );
        }

    }
}