using System;
using ConsoleUI;

Logger obj1 = Logger.GetIstance();
Logger obj2 = Logger.GetIstance();

Console.WriteLine(obj1.GetHashCode());
Console.WriteLine(obj2.GetHashCode());