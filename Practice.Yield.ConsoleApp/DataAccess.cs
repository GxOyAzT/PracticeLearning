using System.Collections.Generic;
using System.Threading;

namespace Practice.Yield.ConsoleApp
{
    public class DataAccess
    {
        public static IEnumerable<PersonModel> GetPeople()
        {
            List<PersonModel> output = new();

            output.Add(new PersonModel("Tim", "Corey"));
            output.Add(new PersonModel("Sue", "Storm"));
            output.Add(new PersonModel("Jane", "Smith"));

            return output;
        }

        public static IEnumerable<PersonModel> GetPeopleYield()
        {
            yield return new PersonModel("Tim", "Corey");
            Thread.Sleep(100);
            yield return new PersonModel("Sue", "Storm");
            Thread.Sleep(100);
            yield return new PersonModel("Jane", "Smith");
        }
    }
}
