using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        
    }

    async Task InsideMain()
    {
        var task1 = (new CountToTen("Method1")).Count(1000);
        var task2 = (new CountToTen("Method1")).Count(1100);

        await task1;
        await task2;
    }
}