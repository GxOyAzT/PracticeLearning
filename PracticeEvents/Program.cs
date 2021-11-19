using System;

namespace PracticeEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var someService = new SomeService();

            someService.DoSomethingInvoked += DomethingServiceEvent;

            someService.DoSomething();
        }

        private static void DomethingServiceEvent()
        {
            Console.WriteLine("DoDomethingServiceEvent() started");
            Console.WriteLine("DoDomethingServiceEvent() ended");
        }
    }
}
