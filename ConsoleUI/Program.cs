using System.Threading.Tasks;
using ClassLibrary.ManyToManyPractice;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    public class Program
	{
		public async static Task Main(string[] args)
		{
			AuthorModel authorModel1 = new AuthorModel() { Name = "Jakub" };
			AuthorModel authorModel2 = null;

			authorModel1.SayYourName();
			authorModel2?.SayYourName();
		}
	}
}