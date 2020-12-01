using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class CarBuilder : ICarBuilder
    {
        public Car _car { get; private set; }

        public CarBuilder()
        {
            _car = new Car();
        }

        public void SetDoors(int n)
        {
            _car.Doors = n;
        }

        public void SetEngine(string eng)
        {
            _car.Engine = "Sport";
        }

        public void SetSeats(int n)
        {
            _car.Seats = n;
        }

        public void SetStering(string stering)
        {
            _car.Stering = stering;
        }

        public Car Build()
        {
            return _car;
        }
    }
}
