using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;

namespace Parking.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository) {

            this.bookingRepository = bookingRepository;
        
        }

        public bool Delete(int id)
        {
            return bookingRepository.Delete(id);
        }

        public Booking Get(int id)
        {
            return bookingRepository.Get(id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return bookingRepository.GetAll();
        }

        public bool Save(Booking entity)
        {
            return bookingRepository.Save(entity);
        }

        public bool Update(Booking entity)
        {
            return bookingRepository.Update(entity);
        }
    }
}