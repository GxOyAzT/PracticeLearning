using System;
using ClassLibrary;

CarBuilder carBuilder = new CarBuilder();
carBuilder.SetDoors(5);
carBuilder.SetSeats(5);
carBuilder.SetEngine("Sport");
carBuilder.SetStering("Wheel");

Car car = carBuilder.Build();

MakeSportCar makeSportCar = new MakeSportCar();

Car sportCar = makeSportCar.Make();

Console.WriteLine();