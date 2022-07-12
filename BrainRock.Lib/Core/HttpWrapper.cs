
#if NET452_OR_GREATER
using System.Net.Http;
using System.Threading.Tasks;
#elif NET35
using System.Net;
#endif

namespace BrainRock.Lib.Core
{
    public static class HttpWrapper
    {
#if NET35
        private static readonly WebClient HttpClient = new WebClient();

        public static string Get(string url)
        {
            return HttpClient.DownloadString(url);
        }

        public static byte[] GetBytes(string url)
        {
            return HttpClient.DownloadData(url);
        }
        public static void Dispose()
        {
            HttpClient.Dispose();
        }
#else
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<string> Get(string url)
        {
            return await HttpClient.GetStringAsync(url);
        }

        public static async Task<byte[]> GetBytes(string url)
        {
            return await HttpClient.GetByteArrayAsync(url);
        }

        public static void Dispose()
        {
            HttpClient.Dispose();
        }
#endif
    }
}