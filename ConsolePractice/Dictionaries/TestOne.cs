using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolePractice.Dictionaries
{
    public static class TestOne
    {
        static Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
        static List<SomeStructTwo> list = new List<SomeStructTwo>();

        public static void Execute()
        {
            for (int i = 1; i < 4000000; i++)
            {
                var guid = Guid.NewGuid();
                dictionary.Add(guid, $"Object - {i}");
                list.Add(new SomeStructTwo() { Id = guid, Name = $"Object - {i}" });
            }

            var searchGuid = list[3800000].Id;

            ExecutionMeasure.Measure(() =>
            {
                var ans = dictionary[searchGuid];
            }, 
            "DICTIONARY", 10);

            ExecutionMeasure.Measure(() =>
            {
                var ans = list.FirstOrDefault(e => e.Id == searchGuid);
            }, 
            "LIST (FirstOrDefault)", 10);
        }
    }

    public struct SomeStruct
    {
        public SomeStruct(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct SomeStructTwo
    {
        public SomeStructTwo(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
