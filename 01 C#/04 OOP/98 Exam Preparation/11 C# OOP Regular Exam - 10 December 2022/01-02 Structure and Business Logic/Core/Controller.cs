using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);

            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            List<IRoom> rooms = new List<IRoom>();

            foreach (var currentHotel in hotels.All().OrderBy(x => x.FullName))
            {
                foreach (var currentRoom in currentHotel.Rooms.All().Where(x => x.PricePerNight > 0))
                {
                    rooms.Add(currentRoom);
                }
            }

            rooms = rooms.OrderBy(x => x.BedCapacity).ToList();

            IRoom room = rooms.FirstOrDefault(x => x.BedCapacity >= adults + children);

            if (hotels.All().FirstOrDefault(x => x.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            if (room == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IHotel hotel = hotels.All().FirstOrDefault(x => x.Rooms.All().Contains(room));

            IBooking booking = new Booking(room, duration, adults, children, hotel.Bookings.All().Count + 1);

            hotel.Bookings.AddNew(booking);

            return string.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Count, hotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine("--Bookings:");

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine();
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine();
                    sb.AppendLine(booking.BookingSummary());
                }
            }

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(Apartment) && roomTypeName != nameof(DoubleBed) && (roomTypeName != nameof(Studio)))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName);

            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (room.PricePerNight > 0)
            {
                throw new ArgumentException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room = null;

            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}