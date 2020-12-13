using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        List<BookModel> books;
        using (var db = new LibraryContext())
        {
            books = db.BookModels.ToList();
        }
    }
}