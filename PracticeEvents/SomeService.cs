using System;

namespace PracticeEvents
{
    public class SomeService
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething() started");

            DoSomethingInvoked?.Invoke();

            Console.WriteLine("DoSomething() ended");
        }

        public event Action DoSomethingInvoked;
    }
}
