using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        const int BedCapacity = 6;

        public Apartment()
            : base(BedCapacity)
        {
        }
    }
}
