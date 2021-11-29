using NETSixPractice.Models;

namespace NETSixPractice;

internal static class AllAboutLinq
{
    static void Execute()
    {
        // Chunk

        var names = new[] { "Name_1", "Name_2", "Name_3", "Name_4", "Name_5", "Name_6", "Name_7", "Name_8" };

        var ans = ChynkBy<string>(names, 3).ToList();

        var ans_linq = names.Chunk(3).ToList();

        // Concat
        var firstSet = new[] { "A", "B" };
        var secondSet = new[] { "C", "D" };
        var thirdSet = new[] { "E", "F" };

        firstSet.Count();

        var setsConcat = firstSet.Concat(secondSet.Concat(thirdSet));

        // Zip
        var ages = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        var yearsOfExperience = new[] { 20, 21, 22, 23, 24, 25, 26, 27, 28 };

        var zipped = names.Zip(ages, yearsOfExperience);

        // MinBy MaxBy

        var family = new List<EmployeeModel>()
        {
            new EmployeeModel() { Name = "Person_1", Age = 10 },
            new EmployeeModel() { Name = "Person_2", Age = 57 },
            new EmployeeModel() { Name = "Person_3", Age = 10 },
            new EmployeeModel() { Name = "Person_4", Age = 1 },
        };

        var youngest = family.MinBy(e => e.Age);
        var oldest = family.MaxBy(e => e.Age);

        var secondItemFromTheEnd = family.ElementAt(^2);

        // Take ..

        var slice = family.Take(1..3);
        var lastThree = family.Take(^3..);

        Console.Read();

        IEnumerable<IEnumerable<T>> ChynkBy<T>(IEnumerable<T> list, int chunkSize)
        {
            return list
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value));
        }
    }
}
