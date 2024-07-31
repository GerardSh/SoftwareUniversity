namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class TelevisionDeviceTests
    {
        TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice("brand", 10, 5, 5);
        }

        [Test]
        public void ConstructorShouldCreateTheObject()
        {
            Assert.NotNull(device);
            Assert.That(device.Brand, Is.EqualTo("brand"));
            Assert.That(device.Price, Is.EqualTo(10));
            Assert.That(device.ScreenWidth, Is.EqualTo(5));
            Assert.That(device.ScreenHeigth, Is.EqualTo(5));
            Assert.That(device.CurrentChannel, Is.EqualTo(0));
            Assert.That(device.Volume, Is.EqualTo(13));
            Assert.False(device.IsMuted);
        }


        [Test]
        public void SwithchOnMethodShouldReturnCorrectValue()
        {
            var result = device.SwitchOn();

            Assert.That(result, Is.EqualTo($"Cahnnel 0 - Volume 13 - Sound On"));

            device.MuteDevice();

            result = device.SwitchOn();

            Assert.That(result, Is.EqualTo($"Cahnnel 0 - Volume 13 - Sound Off"));
        }

        [Test]
        public void ChangeChannelMethodShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => device.ChangeChannel(-1));
        }

        [Test]
        public void ChangeChannelMethodShouldWorkCorrectly()
        {
            device.ChangeChannel(5);

            Assert.That(device.CurrentChannel, Is.EqualTo(5));
        }

        [Test]
        public void VolumeChangeMethodShouldChangeCorrectlyTheVolume()
        {
            device.VolumeChange("UP", 5);

            Assert.That(device.Volume, Is.EqualTo(18));

            device.VolumeChange("UP", -5);

            Assert.That(device.Volume, Is.EqualTo(23));

            device.VolumeChange("UP", 100);

            Assert.That(device.Volume, Is.EqualTo(100));

            device.VolumeChange("DOWN", -50);

            Assert.That(device.Volume, Is.EqualTo(50));

            device.VolumeChange("DOWN", 100);

            Assert.That(device.Volume, Is.EqualTo(0));

            string result = device.VolumeChange("UP", 50);

            Assert.That(result, Is.EqualTo("Volume: 50"));
        }

        [Test]
        public void MuteDeviceShouldReturnCorrectValues()
        {
            bool result = device.MuteDevice();

            Assert.True(result);

            result = device.MuteDevice();

            Assert.False(result);
        }

        [Test]
        public void ToStringMethodShouldReturnCorrectInformation()
        {
            string result = device.ToString();

            Assert.That(result, Is.EqualTo("TV Device: brand, Screen Resolution: 5x5, Price 10$"));
        }
    }
}