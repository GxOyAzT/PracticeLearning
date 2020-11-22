using ConsoleUI;
using System;

Console.WriteLine("Hello");
Console.WriteLine(Add(15.47, 13));

static double Add(double a, double b)
{
    return a + b;
}

// object type shorthand instatntion
PersonModel p2 = new(2, "Jakub", "Koza");
PersonModel personModel = new() { Id = 1, FirstName = "Tim", LastName = "Corey" };

Console.WriteLine($"Hello { personModel.FirstName } { personModel.LastName } ({ personModel.Id })");

//personModel.Id = 2;
personModel.FirstName = "Timothy";