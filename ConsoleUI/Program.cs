using System;
using ClassLibrary;

PersonModel person = new PersonModel()
{
    Id = Guid.NewGuid(),
    FullName = "AAA",
    Age = 55
};

PersonModel clonePerson = person.Clone();

clonePerson.Age = 10;

Console.WriteLine();