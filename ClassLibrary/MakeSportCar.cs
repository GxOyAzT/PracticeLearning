using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class MakeSportCar
    {
        public Car Make()
        {
            CarBuilder carBuilder = new CarBuilder();

            carBuilder.SetDoors(5);
            carBuilder.SetSeats(2);
            carBuilder.SetEngine("Sport");
            carBuilder.SetStering("Console");

            return carBuilder.Build();
        }
    }
}
