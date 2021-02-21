using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ParallelPractice
{
    public static class RandomFileGenerator
    {
        static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuwyz0123456789";
            return new string(Enumerable.Repeat(chars, (new Random()).Next(5,1000))
              .Select(s => s[(new Random()).Next(s.Length)]).ToArray());
        }

        static string RandomRow()
        {
            return $"{RandomString()},{(new Random()).Next(int.MinValue + 1, int.MaxValue - 1)},{DateTime.Now.Date.AddDays((new Random()).Next(-20000, 20000))}";
        }

        static void InsertRandomRowIntoTXT()
        {
            using StreamWriter file = new StreamWriter(@"C:\Data\Projects\PracticeLearning\ParallelPractice\randomData.txt", true);
            file.WriteLine(RandomRow());
        }

        public static void InsertRowsIntoTXT(int rowsCount)
        {
            for (int i = 0; i < rowsCount; i++)
            {
                InsertRandomRowIntoTXT();
            }
        }
    }
}
