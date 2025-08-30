using System.Net.Http;
using System.Threading.Tasks;

namespace SpaceCatGamesDevTool.Services
{
    public class ApiChecker
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<int> CheckApiStatusAsync(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                return (int)response.StatusCode;
            }
            catch
            {
                return -1; // Indicates error
            }
        }
    }
}
