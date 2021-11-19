using System;

namespace Practice.Attributes.ConsoleApp
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    internal sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; }
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
