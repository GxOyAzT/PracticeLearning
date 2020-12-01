using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public interface ICarBuilder
    {
        void SetSeats(int n);
        void SetDoors(int n);
        void SetEngine(string eng);
        void SetStering(string stering);
    }
}
