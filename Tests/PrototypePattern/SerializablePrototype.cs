using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Xunit;

namespace Tests.PrototypePatternSerializable
{
    public class SerializablePrototype
    {
        [Fact]
        public void TestA()
        {
            Employee emp1 = new Employee()
            {
                Id = 101,
                Name = "Empp 1",
                Dob = DateTime.Now.Date,
                Department = new Department()
                {
                    Id = 11,
                    Name = "Dep 1"
                }
            };

            Employee emp2 = DeppCopy<Employee>.Copy(emp1);

            emp2.Id = 102;
            emp2.Department.Name = "Dep 2";

            Assert.Equal(101, emp1.Id);
            Assert.Equal("Dep 1", emp1.Department.Name);

            Assert.Equal(102, emp2.Id);
            Assert.Equal("Dep 2", emp2.Department.Name);
        }
    }

    public class DeppCopy<T>
    {
        public static T Copy(T entity)
        {
            using (var memoryStream = new MemoryStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(memoryStream, entity);
                memoryStream.Position = 0;
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }
    }

    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Department Department { get; set; }
    }

    [Serializable]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
