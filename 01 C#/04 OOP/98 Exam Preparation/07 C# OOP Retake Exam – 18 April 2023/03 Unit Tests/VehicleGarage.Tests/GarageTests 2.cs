using NUnit.Framework;
using System.Collections.Generic;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        Vehicle vehicle;
        Garage garage;

        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle("brand", "model", "license");
            garage = new Garage(10);
        }

        [Test]
        public void VehicleConstructorShouldCreateTheObject()
        {
            Assert.IsNotNull(vehicle);
            Assert.That(vehicle.Brand, Is.EqualTo("brand"));

            vehicle.Brand = "brand2";

            Assert.That(vehicle.Brand, Is.EqualTo("brand2"));
            Assert.That(vehicle.Model, Is.EqualTo("model"));

            vehicle.Model = "model2";

            Assert.That(vehicle.Model, Is.EqualTo("model2"));
            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo("license"));

            vehicle.LicensePlateNumber = "license2";

            Assert.That(vehicle.LicensePlateNumber, Is.EqualTo("license2"));
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));

            vehicle.BatteryLevel = 10;

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(10));
            Assert.That(vehicle.IsDamaged, Is.EqualTo(false));

            vehicle.IsDamaged = true;

            Assert.That(vehicle.IsDamaged, Is.EqualTo(true));
        }

        [Test]
        public void GarageConstructorShouldCreateTheObject()
        {
            Assert.IsNotNull(garage);
            Assert.IsNotNull(garage.Vehicles);

            Assert.That(garage.Capacity, Is.EqualTo(10));

            garage.Capacity = 20;

            Assert.That(garage.Capacity, Is.EqualTo(20));

            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));

            garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(garage.Vehicles[0].Model, Is.EqualTo("model"));

            garage.Vehicles.Add(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(2));

            garage.Vehicles = new List<Vehicle>();

            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddVehicleMethodShouldReturnCorrectValue()
        {
            Vehicle vehicle2 = new Vehicle("brand2", "model2", "license2");

            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));

            garage.Capacity = 1;

            garage.AddVehicle(vehicle);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));

            bool result = garage.AddVehicle(vehicle2);

            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.False(result);

            garage.Capacity = 10;

            result = garage.AddVehicle(vehicle2);

            Assert.True(result);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(2));
            Assert.That(garage.Vehicles[1].Model, Is.EqualTo("model2"));

            result = garage.AddVehicle(vehicle2);

            Assert.False(result);
        }

        [Test]
        public void ChargeVehicleMethodShouldReturnCorrectValue()
        {
            Vehicle vehicle2 = new Vehicle("brand2", "model2", "license2");

            vehicle2.BatteryLevel = 10;

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(10));

            garage.Vehicles.Add(vehicle);
            garage.Vehicles.Add(vehicle2);

            int result = garage.ChargeVehicles(20);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(100));

            Assert.That(result, Is.EqualTo(1));

            vehicle2.BatteryLevel = 10;
            garage.Vehicles[0].BatteryLevel = 0;

            Assert.That(garage.Vehicles[0].BatteryLevel, Is.EqualTo(0));

            result = garage.ChargeVehicles(10);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(100));

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void DriveVehicleMethodShouldReturnCorrectValue()
        {
            Vehicle vehicle2 = new Vehicle("brand2", "model2", "license2");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);

            vehicle2.IsDamaged = true;
            vehicle2.BatteryLevel = 20;

            garage.DriveVehicle("license2", 10, true);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(20));

            vehicle2.IsDamaged = false;

            garage.DriveVehicle("license2", 200, true);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(20));

            garage.DriveVehicle("license2", 30, true);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(20));

            garage.DriveVehicle("license2", 20, true);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(0));
            Assert.That(vehicle2.IsDamaged, Is.EqualTo(true));

            vehicle2.BatteryLevel = 21;
            vehicle2.IsDamaged = false;

            garage.DriveVehicle("license2", 20, false);

            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(1));
            Assert.That(vehicle2.IsDamaged, Is.EqualTo(false));
        }

        [Test]
        public void RepairVehicleMethodShouldReturnCorrectValue()
        {
            Vehicle vehicle2 = new Vehicle("brand2", "model2", "license2");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);

            vehicle.IsDamaged = true;

            Assert.True(vehicle.IsDamaged);

            string result = garage.RepairVehicles();

            Assert.False(vehicle.IsDamaged);
            Assert.That(result, Is.EqualTo("Vehicles repaired: 1"));

            result = garage.RepairVehicles();

            Assert.That(result, Is.EqualTo("Vehicles repaired: 0"));
        }
    }
}