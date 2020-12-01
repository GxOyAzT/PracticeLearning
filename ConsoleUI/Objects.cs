using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    interface ISaveData
    {
        void Save(string data);
    }

    class SaveDataToSql : ISaveData
    {
        public void Save(string data)
        {
            Console.WriteLine("\nSave data to SQL.\n");
        }
    }

    class SaveDataToFile : ISaveData
    {
        public void Save(string data)
        {
            Console.WriteLine("\nSave data to FILE.\n");
        }
    }

    class SaveDataToOracle : ISaveData
    {
        public void Save(string data)
        {
            Console.WriteLine("\nSave data to ORACLE.\n");
        }
    }

    class Creator
    {
        public static ISaveData Create(int x)
        {
            switch (x)
            {
                case 1:
                    return new SaveDataToFile();
                case 2:
                    return new SaveDataToSql();
                case 3:
                    return new SaveDataToOracle();
                default:
                    throw new Exception("Incorrect data format.");
            }
        }
    }
}
