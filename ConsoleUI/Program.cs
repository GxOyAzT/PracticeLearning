using ClassLibrary;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        using (var db = new LibraryContext())
        {
            var authors = db.AuthorModels.ToList();
            for (int i = 0; i < 1500; i++)
            {
                db.Add(GenerateRandomBook.Generate(authors));
            }
            db.SaveChanges();
        }
    }
}