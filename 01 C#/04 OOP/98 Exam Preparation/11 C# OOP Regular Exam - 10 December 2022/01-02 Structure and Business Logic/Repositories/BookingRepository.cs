using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        List<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }

        public void AddNew(IBooking model) => models.Add(model);

        public IReadOnlyCollection<IBooking> All() => models;

        public IBooking Select(string criteria) => models.FirstOrDefault(x => x.BookingNumber == int.Parse(criteria));
    }
}
