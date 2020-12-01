using ConsoleUI;
using System;

Console.WriteLine();

for (; ; )
{
    ISaveData saveData = Creator.Create(GetUserInput());

    saveData.Save("Hello");
}

int GetUserInput()
{
    for(; ; )
    {
        Console.WriteLine("Save to file: 1");
        Console.WriteLine("Save to sql: 2");

        int userInput = Convert.ToInt32(Console.ReadLine());

        if (userInput is not 1 and not 2 and not 3) 
            continue;
        else 
            return userInput;
    }
}