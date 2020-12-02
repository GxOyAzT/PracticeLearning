using System;
using ClassLibrary;

IInterfaceA interA = new ClassAB();

interA.Method();

IInterfaceB interB = new ClassAB();

interB.Method();

ClassAB classAB = new();

Console.WriteLine();