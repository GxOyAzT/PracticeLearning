using System.Net.Http;
using System.Threading.Tasks;

namespace ConsolePractice.GetAsync
{
    public static class GetAsync
    {
        public static async Task<string> Get(string link)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(link);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
