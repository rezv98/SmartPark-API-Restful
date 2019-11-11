using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Domain;
using Parking.Repository.Context;
using Parking.Repository.DTO;

namespace Parking.Repository.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private ApplicationDbContext context;
        public BookingRepository(ApplicationDbContext context) {

            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var booking = context.bookings.Single(x => x.Id == id);
                context.Remove(booking);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
            return true;
        }

        public BookingDTO Get(int id)
        {
            var result=new BookingDTO();
            try
            {
                var booking= context.bookings.Include(x=>x.Space).Include(x=>x.Vehicle).Single(x => x.Id == id);
                result.Id=booking.Id;
                result.ArrivingTime=booking.ArrivingTime;
                result.SpaceId=booking.SpaceId;
                result.spaceTag=booking.Space.Tag;
                result.Status=booking.Status;
                result.carplate=booking.Vehicle.CarPlate;
                result.VehicleId=booking.VehicleId;

            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            var result = new List<BookingDTO>();
            try
            {
              var  bookings = context.bookings.Include(x=>x.Vehicle).Include(x=>x.Space);
                result=bookings.Select(Booking=>new BookingDTO{Id=Booking.Id,VehicleId=Booking.VehicleId,ArrivingTime=Booking.ArrivingTime,carplate=Booking.Vehicle.CarPlate,SpaceId=Booking.SpaceId,spaceTag=Booking.Space.Tag,Status=Booking.Status}).ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(BookingDTO entity)
        {
            try
            {
                

                context.Add(new Booking{

                    
                    SpaceId=entity.SpaceId,
                    VehicleId=entity.VehicleId,
                    Status=entity.Status,
                    ArrivingTime=entity.ArrivingTime
                });
                context.SaveChanges();
              
            }
            catch (System.Exception)
            {
                
               throw;
            }
            return true;
        }

        public bool Update(BookingDTO entity)
        {
            try{
                
                
                var booking =context.bookings.Single(x => x.Id == entity.Id);
                booking.Id = entity.Id;
                booking.ArrivingTime = entity.ArrivingTime;
                booking.Status = entity.Status;
                
                context.Update(booking);
                context.SaveChanges();

            }catch(System.Exception){
                return false;

            }
            return true;
        }
    }
}