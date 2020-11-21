using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Jakub");
            dic.Add(2, "Marek");
            dic.Add(3, "Kacper");
            dic.Add(4, "Filip");

            var ans = dic.ContainsKey(5);
            var ans2 = dic.ContainsKey(1);

            var ans3 = dic.ContainsValue("Patryk");
            var ans4 = dic.ContainsValue("Marek");

            Dictionary<int, Employee1> dicEmp1 = new Dictionary<int, Employee1>();
            dicEmp1.Add(1, new Employee1() { Id = 1, Name = "Jakub" });
            dicEmp1.Add(2, new Employee1() { Id = 2, Name = "Marek" });
            dicEmp1.Add(3, new Employee1() { Id = 3, Name = "Kacper" });
            dicEmp1.Add(4, new Employee1() { Id = 4, Name = "Filip" });

            // WARNING
            // When we want to check if class object is present in a dictionary collection
            // then we have to implement IEquatable<class_name> interface with Equals() method.
            var ans5 = dicEmp1.ContainsValue(new Employee1() { Id = 1, Name = "Jakub" });
            var nas6 = dicEmp1.ContainsValue(new Employee1() { Id = 10, Name = "Daria" });


        }
    }
}
