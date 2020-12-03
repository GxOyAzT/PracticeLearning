using System;
using ClassLibrary;

IInterfaceA interA = new ClassAB();

interA.Method();

IInterfaceB interB = new ClassAB();

interB.Method();

ClassAB classAB = new() { x = 10 };

classAB.IncrementX(10);

Console.WriteLine();