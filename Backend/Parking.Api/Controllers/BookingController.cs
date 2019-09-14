using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
namespace Parking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController:ControllerBase
    {
        private IBookingService bookingService;
        public BookingController(IBookingService bookingService){
            this.bookingService=bookingService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                bookingService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Booking booking)
        {
            return Ok(
                bookingService.Save(booking)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Booking booking)
        {
            return Ok(
                bookingService.Update(booking)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                bookingService.Delete(id)
            );
        }
    }
}