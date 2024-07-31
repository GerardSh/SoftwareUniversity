namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class DeviceTests
    {
        Device device;

        [SetUp]
        public void Setup()
        {
            device = new Device(10);
        }

        [Test]
        public void ConstructorShouldCreateTheObject()
        {
            Assert.IsNotNull(device);
            Assert.That(device.MemoryCapacity, Is.EqualTo(10));
            Assert.That(device.AvailableMemory, Is.EqualTo(10));
            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
        }

        [Test]
        public void TakePhotoMethodShouldReturnCorrectValue()
        {
            Assert.That(device.Photos, Is.EqualTo(0));

            bool result = device.TakePhoto(10);

            Assert.That(result, Is.True);
            Assert.That(device.AvailableMemory, Is.EqualTo(0));
            Assert.That(device.Photos, Is.EqualTo(1));
            Assert.That(device.MemoryCapacity, Is.EqualTo(10));

            result = device.TakePhoto(1);

            Assert.That(result, Is.False);
            Assert.That(device.Photos, Is.EqualTo(1));

            Device device2 = new Device(10);

            result = device2.TakePhoto(1);

            Assert.That(result, Is.True);
            Assert.That(device2.AvailableMemory, Is.EqualTo(9));
            Assert.That(device2.Photos, Is.EqualTo(1));
            Assert.That(device2.MemoryCapacity, Is.EqualTo(10));
        }

        [Test]
        public void InstallAppMethodShouldInstallTheApplicationCorrectlyAndThrowExceptionWhenNotEnoughMemory()
        {
            Assert.That(device.Applications.Count, Is.EqualTo(0));

            string result = device.InstallApp("app", 5);

            Assert.That(result, Is.EqualTo("app is installed successfully. Run application?"));
            Assert.That(device.AvailableMemory, Is.EqualTo(5));
            Assert.That(device.Applications.Count, Is.EqualTo(1));
            Assert.That(device.MemoryCapacity, Is.EqualTo(10));

            result = device.InstallApp("app2", 5);

            Assert.That(result, Is.EqualTo("app2 is installed successfully. Run application?"));
            Assert.That(device.AvailableMemory, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(2));
            Assert.That(device.MemoryCapacity, Is.EqualTo(10));

            Assert.Throws<InvalidOperationException>(() => device.InstallApp("app3", 1));
        }

        [Test]
        public void FormatDeviceMethodShouldWOrkCorrectly()
        {
            device.TakePhoto(5);
            device.InstallApp("app", 5);

            Assert.That(device.AvailableMemory, Is.EqualTo(0));
            Assert.That(device.Applications.Count, Is.EqualTo(1));
            Assert.That(device.Photos, Is.EqualTo(1));

            device.FormatDevice();

            Assert.That(device.AvailableMemory, Is.EqualTo(10));
            Assert.That(device.Applications.Count, Is.EqualTo(0));
            Assert.That(device.Photos, Is.EqualTo(0));
        }

        [Test]
        public void GetDeviceStatusShouldWorkCorrectlyAndReturnCorrectInformation()
        {
            string expectedResult = $"Memory Capacity: 10 MB, Available Memory: 10 MB{Environment.NewLine}Photos Count: 0{Environment.NewLine}Applications Installed:";

            Assert.That(expectedResult, Is.EqualTo(device.GetDeviceStatus()));

            device.TakePhoto(1);
            device.InstallApp("app", 5);

            expectedResult = $"Memory Capacity: 10 MB, Available Memory: 4 MB{Environment.NewLine}Photos Count: 1{Environment.NewLine}Applications Installed: app";

            Assert.That(expectedResult, Is.EqualTo(device.GetDeviceStatus()));
        }
    }
}