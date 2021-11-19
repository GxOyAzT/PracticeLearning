namespace TestsPractice.Application
{
    public interface IServiceA
    {
        string ReturnValue(string someValue);
    }

    public class ServiceA : IServiceA
    { 

        public string ReturnValue(string someValue)
        {
            return someValue;
        }
    }
}
