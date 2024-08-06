using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        List<IHotel> models;

        public HotelRepository()
        {
            models = new List<IHotel>();
        }

        public void AddNew(IHotel model) => models.Add(model);

        public IReadOnlyCollection<IHotel> All() => models;

        public IHotel Select(string criteria) => models.FirstOrDefault(x => x.FullName == criteria);
    }
}
