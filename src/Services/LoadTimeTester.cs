using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpaceCatGamesDevTool.Services
{
    public class LoadTimeTester
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<long> TestLoadTimeAsync(string url)
        {
            try
            {
                var stopwatch = Stopwatch.StartNew();
                var response = await client.GetAsync(url);
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
            catch
            {
                return -1; // Indicates error
            }
        }
    }
}
