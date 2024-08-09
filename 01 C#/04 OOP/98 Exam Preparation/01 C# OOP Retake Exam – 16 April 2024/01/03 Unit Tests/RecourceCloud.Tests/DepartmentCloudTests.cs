using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        Task task;
        Resource resource;
        DepartmentCloud departmentCloud;

        [SetUp]
        public void Setup()
        {
            task = new Task(1, "label", "resource name");
            resource = new Resource("name", "type");
            departmentCloud = new DepartmentCloud();
        }

        [Test]
        public void ConstructorTaskShouldCreateObject()
        {
            Assert.IsNotNull(task);
            Assert.That(task.Label, Is.EqualTo("label"));
            Assert.That(task.ResourceName, Is.EqualTo("resource name"));
            Assert.That(task.Priority, Is.EqualTo(1));
        }

        [Test]
        public void ConstructorResourceShouldCreateObject()
        {
            Assert.IsNotNull(resource);
            Assert.That(resource.Name, Is.EqualTo("name"));
            Assert.That(resource.ResourceType, Is.EqualTo("type"));
            Assert.That(resource.IsTested, Is.EqualTo(false));
        }

        [Test]
        public void ConstructorDepartmentCloudShouldCreateObject()
        {
            Assert.IsNotNull(departmentCloud);
            Assert.IsNotNull(departmentCloud.Tasks);
            Assert.IsNotNull(departmentCloud.Resources);
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            Assert.That(departmentCloud.Resources.Count, Is.EqualTo(0));
        }

        [Test]
        public void LogTaskMethodShouldThrowExceptionIfNotCorrectNumberOfArgumentsAreProvided()
        {
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", "2" }));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] {}));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", "2", "3", "4"}));
        }

        [Test]
        public void LogTaskMethodShouldThrowExceptionIfAnyOfTheArgumentIsNull()
        {
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { null, "2", "3" }));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", null, "3" }));
            Assert.Throws<ArgumentException>(() => departmentCloud.LogTask(new string[] { "1", "2", null }));
        }

        [Test]
        public void LogTaskMethodShouldReturnMessageIfResourceIsAlreadyLogged()
        {
            departmentCloud.LogTask(new string[] { "1", "2", "3" });

            string result = departmentCloud.LogTask(new string[] { "1", "2", "3" });

            Assert.That(result, Is.EqualTo($"3 is already logged."));
        }

        [Test]
        public void LogTaskMethodShouldAddTheResourceCorrectly()
        {
            string result = departmentCloud.LogTask(new string[] { "1", "2", "3" });

            Assert.That(result, Is.EqualTo($"Task logged successfully."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
        }

        [Test]
        public void CreateResourceMethodShouldReturnFalse()
        {
            bool result = departmentCloud.CreateResource();

            Assert.That(result, Is.False);
        }

        [Test]
        public void CreateResourceMethodShouldReturnTrueRemoveTaskFromTasksAndAddToResources()
        {
            departmentCloud.LogTask(new string[] { "1", "2", "3" });
            bool result = departmentCloud.CreateResource();

            Assert.That(result, Is.True);
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
            Assert.That(departmentCloud.Resources.First().Name == "3");
            Assert.That(departmentCloud.Resources.First().ResourceType == "2");
        }

        [Test]
        public void TestResourceMethodShouldReturnNull()
        {
            departmentCloud.LogTask(new string[] { "1", "2", "3" });
            departmentCloud.CreateResource();

            var result = departmentCloud.TestResource("4");

            Assert.IsNull(result);
        }

        [Test]
        public void TestResourceMethodShouldReturnTheResource()
        {


            departmentCloud.LogTask(new string[] { "1", "2", "3" });
            departmentCloud.CreateResource();

            var result = departmentCloud.TestResource("3");

            Assert.That(result.IsTested, Is.EqualTo(true));
            Assert.That(result.Name, Is.EqualTo("3"));
            Assert.That(result.ResourceType, Is.EqualTo("2"));
        }
    }
}