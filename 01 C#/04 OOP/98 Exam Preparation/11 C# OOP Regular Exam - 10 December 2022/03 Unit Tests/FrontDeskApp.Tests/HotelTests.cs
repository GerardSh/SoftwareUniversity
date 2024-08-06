using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class HotelTests
    {
        Room room;
        Booking booking;
        Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(10, 10);
            booking = new Booking(10, room, 10);
            hotel = new Hotel("name", 5);
        }

        [Test]
        public void ConstructorsShouldCreateObjectsCorrectly()
        {
            Assert.Throws<ArgumentException>(() => new Room(0, 10));
            Assert.Throws<ArgumentException>(() => new Room(-1, 10));
            Assert.Throws<ArgumentException>(() => new Room(10, 0));
            Assert.Throws<ArgumentException>(() => new Room(10, -1));

            Assert.That(room, Is.Not.Null);
            Assert.That(room.BedCapacity, Is.EqualTo(10));
            Assert.That(room.PricePerNight, Is.EqualTo(10));

            Assert.That(booking, Is.Not.Null);
            Assert.That(booking.Room, Is.EqualTo(room));
            Assert.That(booking.BookingNumber, Is.EqualTo(10));
            Assert.That(booking.ResidenceDuration, Is.EqualTo(10));

            Assert.Throws<ArgumentNullException>(() => new Hotel("", 10));
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 10));
            Assert.Throws<ArgumentException>(() => new Hotel("name", 0));
            Assert.Throws<ArgumentException>(() => new Hotel("name", 6));

            Assert.That(hotel, Is.Not.Null);
            Assert.That(hotel.FullName, Is.EqualTo("name"));
            Assert.That(hotel.Category, Is.EqualTo(5));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(0));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Rooms, Is.Not.Null);
            Assert.That(hotel.Bookings, Is.Not.Null);
            Assert.That(hotel.Turnover, Is.EqualTo(0));
        }

        [Test]
        public void AddRoomMethodSHouldWorkCorrectly()
        {
            Assert.That(hotel.Rooms.Count, Is.EqualTo(0));

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms.First(), Is.EqualTo(room));
        }

        [Test]
        public void BookRoomMethodShouldWOrkCorrectly()
        {
            Room room2 = new Room(4, 10);
            Room room3 = new Room(3, 10);
            Room room4 = new Room(4, 200);

            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.AddRoom(room4);


            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 1, 10));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 1, 1, 10));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 1, 10));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 0, 0, 10));

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));

            hotel.BookRoom(20, 1, 3, 100);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));

            hotel.BookRoom(3, 1, 3, 1);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(0));
            Assert.That(hotel.Turnover, Is.EqualTo(0));

            hotel.BookRoom(3, 1, 3, 30);

            Assert.That(hotel.Turnover, Is.EqualTo(60));
            Assert.That(hotel.Bookings.Count, Is.EqualTo(2));

            hotel.BookRoom(3, 1, 3, 30);

            Assert.That(hotel.Bookings.Count, Is.EqualTo(4));
            Assert.That(hotel.Turnover, Is.EqualTo(120));
        }
    }
}