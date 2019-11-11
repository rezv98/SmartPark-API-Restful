using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Domain;
using Parking.Repository.Context;

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
                return false;
            }
            return true;
        }

        public Booking Get(int id)
        {
            var result = new Booking();
            try
            {
                result = context.bookings.Include(x=>x.Space).Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public IEnumerable<Booking> GetAll()
        {
            var result = new List<Booking>();
            try
            {
                result = context.bookings.Include(x=>x.Vehicle).ToList();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return result;
        }

        public bool Save(Booking entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
              
            }
            catch (System.Exception)
            {
                
                return false;
            }
            return true;
        }

        public bool Update(Booking entity)
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