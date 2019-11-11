using System.Collections.Generic;
using Parking.Domain;
using Parking.Repository;
using Parking.Repository.DTO;

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

        public BookingDTO Get(int id)
        {
            return bookingRepository.Get(id);
        }

        public IEnumerable<BookingDTO> GetAll()
        {
            return bookingRepository.GetAll();
        }

        public bool Save(BookingDTO entity)
        {
            return bookingRepository.Save(entity);
        }

        public bool Update(BookingDTO entity)
        {
            return bookingRepository.Update(entity);
        }
    }
}