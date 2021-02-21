using System;
using System.Threading.Tasks;

namespace TaskPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw1 = new System.Diagnostics.Stopwatch();
            sw1.Start();
            await RestApiClient.CallApiAsyncImmadiatelyAwait();
            sw1.Stop();


            System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();
            sw2.Start();
            await RestApiClient.CallApiAsyncDeferredAwait();
            sw2.Stop();

            Console.WriteLine(sw1.ElapsedMilliseconds);
            Console.WriteLine(sw2.ElapsedMilliseconds);
        }
    }
}
