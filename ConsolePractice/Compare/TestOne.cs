using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsolePractice.Compare
{
    public class TestOne
    {
        public static void Execute()
        {
            List<SomeClass> someClasses = new List<SomeClass>()
            {
                new SomeClass() { Id = 2, SubId = 1 },
                new SomeClass() { Id = 3, SubId = 2 },
                new SomeClass() { Id = 3, SubId = 3 },
                new SomeClass() { Id = 1, SubId = 1 },
                new SomeClass() { Id = 3, SubId = 1 },
                new SomeClass() { Id = 1, SubId = 2 },
            };

            someClasses.Sort(new SomeClassCompIdAndSubId());

            someClasses.ForEach(e => Console.WriteLine(e.ToString()));
        }
    }

    public class SomeClass
    {
        public int Id { get; set; }
        public int SubId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} SubId: {SubId}";
        }
    }

    public class SomeClassCompId : IComparer<SomeClass>
    {
        public int Compare([AllowNull] SomeClass x, [AllowNull] SomeClass y)
        {
            if (x.Id < y.Id)
                return -1;
            else if (x.Id == y.Id)
                return 0;
            else if (x.Id > y.Id)
                return 1;

            throw new Exception();
        }
    }

    public class SomeClassCompIdAndSubId : IComparer<SomeClass>
    {
        public int Compare([AllowNull] SomeClass x, [AllowNull] SomeClass y)
        {
            if (x.Id < y.Id)
                return -1;
            else if (x.Id == y.Id)
            {
                if (x.SubId < y.SubId)
                    return -1;
                else if (x.SubId == y.SubId)
                    return 0;
                else if (x.SubId > y.SubId)
                    return 1;

                throw new Exception();
            }
            else if (x.Id > y.Id)
                return 1;

            throw new Exception();
        }
    }
}
