namespace TestsPractice.Application
{
    public interface IServiceB
    {
        string returnValue(bool shouldExecute, string someValue);
    }

    public class ServiceB : IServiceB
    {
        private readonly IServiceA serviceA;

        public ServiceB(IServiceA serviceA)
        {
            this.serviceA = serviceA;
        }

        public string returnValue(bool shouldExecute, string someValue)
        {
            if (shouldExecute)
            {
                return serviceA.ReturnValue(someValue);
            }

            return "";
        }
    }
}
