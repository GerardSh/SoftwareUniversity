using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        private List<Car> cars;

        private int capacity;

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            //Option 1
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";

            }
            else if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            //Option 2
            foreach (var c in cars)
            {
                if (c.RegistrationNumber == car.RegistrationNumber)
                {
                    return "Car with that registration number, already exists!";
                }
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            //Option 1         
            if (!cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }

            //Option 2
            foreach (var car in cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
                    return $"Successfully removed {registrationNumber}";
                }
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                cars.RemoveAll(c => c.RegistrationNumber == registrationNumbers[i]);
            }
        }
    }
}