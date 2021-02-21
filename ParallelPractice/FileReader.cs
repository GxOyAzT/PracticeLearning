using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParallelPractice
{
    public class FileReader
    {
        public static List<MyObject> Read()
        {
            List<MyObject> myObjects = new List<MyObject>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Data\Projects\PracticeLearning\ParallelPractice\randomData.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var rowArr = line.Split(',');
                myObjects.Add(new MyObject()
                {
                    StringProp = rowArr[0],
                    IntProp = Convert.ToInt32(rowArr[1]),
                    DateTimeProp = Convert.ToDateTime(rowArr[2])
                });
            };

            return myObjects;
        }

        public static List<MyObject> ReadParallel()
        {
            List<MyObject> myObjects = new List<MyObject>();

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Data\Projects\PracticeLearning\ParallelPractice\randomData.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                Parallel.Invoke(() =>
                {
                    var rowArr = line.Split(',');
                    myObjects.Add(new MyObject()
                    {
                        StringProp = rowArr[0],
                        IntProp = Convert.ToInt32(rowArr[1]),
                        DateTimeProp = Convert.ToDateTime(rowArr[2])
                    });
                });
            };

            return myObjects;
        }
    }

    public class MyObject
    {
        public string StringProp { get; set; }
        public int IntProp { get; set; }
        public DateTime DateTimeProp { get; set; }
    }
}
