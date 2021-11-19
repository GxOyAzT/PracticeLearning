using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Tests.BuilderPattern
{
    //public class BuilderFluentInheritance
    //{
    //    [Fact]
    //    public void TestA()
    //    {
    //        var person = Person.New.Called("John").Department(Department.IT);
    //    }
    //}

    //public class PersonBuilder
    //{
    //    protected Person Person { get; set; }

    //    public PersonBuilder()
    //    {
    //        Person = new Person();
    //    }
    //}

    //public class PersonInfoBuilder<SELF> : PersonBuilder where SELF : PersonInfoBuilder<SELF>
    //{
    //    public SELF Called(string name)
    //    {
    //        Person.Name = name;
    //        return (SELF)this;
    //    }
    //}

    //public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    //{
    //    public SELF Department(Department department)
    //    {
    //        Person.Department = department;
    //        return (SELF) this;
    //    }
    //}

    //public class Person
    //{
    //    public string Name { get; set; }
    //    public Department Department { get; set; }

    //    public class Builder : PersonJobBuilder<Builder>
    //    {
    //        internal Builder() { }
    //    }

    //    public static Builder New => new Builder();
    //}

    //public enum Department
    //{
    //    IT,
    //    HR
    //}
}
