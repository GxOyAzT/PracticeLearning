using System;
using ConsoleUI;

Person person = new()
{
    Name = "Jakub",
    Age = 60,
    Income = 1500f
};

Request request = new Request() { Data = person };

MaxAgeHandler maxAgeHandler = new();
MaxNameLengthHandler MaxNameLengthHandler = new();
MaxIncomeHandler MaxIncomeHandler = new();

maxAgeHandler.SetNextHandler(MaxNameLengthHandler);
MaxNameLengthHandler.SetNextHandler(MaxIncomeHandler);

maxAgeHandler.Process(request);

foreach(var message in request.ValidationMessages)
{
    Console.WriteLine(message);
}