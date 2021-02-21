using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParallelPractice
{
    public static class CallApi
    {
        static HttpClient httpClient = new HttpClient();

        public async static Task Call(string x)
        {
            var result = await httpClient.GetAsync(@"http://localhost:5000/api1.1/employee");
            Console.WriteLine($"Call Api {x}");
        }

        public static async Task CallApiSync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Call("SYNC");
            }
        }

        public async static Task CallApiAsync()
        {
            Parallel.For(1, 11, async e => { await Call("ASYNC"); });
        }
    }
}
