using Parking.Domain;
using Parking.Service;
using Microsoft.AspNetCore.Mvc;
using Parking.Repository.DTO;

namespace Parking.Api.Controllers
{
    [Route("api/bookings")]
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
        public ActionResult Post([FromBody] BookingDTO booking)
        {
            return Ok(
                bookingService.Save(booking)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] BookingDTO booking)
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