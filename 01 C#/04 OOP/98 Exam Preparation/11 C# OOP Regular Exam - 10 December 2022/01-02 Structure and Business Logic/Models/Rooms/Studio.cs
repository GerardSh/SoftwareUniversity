using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        const int BedCapacity = 4;

        public Studio()
            : base(BedCapacity)
        {
        }
    }
}
