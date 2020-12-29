using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPractice
{
    public class HardcodedData
    {
        public static List<ObjectModel> GetObjectModels()
        {
            return new List<ObjectModel>()
            {
                new ObjectModel()
                {
                    Id = Guid.Parse("0200dc24-c984-4df5-9643-7ed353746b70"),
                    Name = "object - 1"
                },
                new ObjectModel()
                {
                    Id = Guid.Parse("70a37192-741a-4b75-b067-ad58d6f4374f"),
                    Name = "object - 2"
                }
            };
        }
    }

    public class ObjectModel 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
