using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskPractice
{
    public class RestApiClient
    {
        public static HttpClient httpClient = new HttpClient();

        public static async Task<HttpStatusCode> Call()
        {
            var result = await httpClient.GetAsync(@"http://localhost:5000/api1.1/employee");
            return result.StatusCode;
        }

        public static async Task CallApiAsyncImmadiatelyAwait()
        {
            var resut1 = await Call();
            var resut2 = await Call();
            var resut3 = await Call();
            var resut4 = await Call();
            var resut5 = await Call();
            var resut6 = await Call();
        }

        public static async Task CallApiAsyncDeferredAwait()
        {
            var resut1 = Call();
            var resut2 = Call();
            var resut3 = Call();
            var resut4 = Call();
            var resut5 = Call();
            var resut6 = Call();

            await resut1;
            await resut2;
            await resut3;
            await resut4;
            await resut5;
            await resut6;
        }
    }
}
