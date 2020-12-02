using System;
using ClassLibrary;

Model x = new();

SubModel y ;

y = x as SubModel;

if (y != null)
    Console.WriteLine("OK");
else
    Console.WriteLine("NOT OK");
    

Console.WriteLine();