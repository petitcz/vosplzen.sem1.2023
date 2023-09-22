using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vosplzen.sem1h3cons.Services
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class DownloadService : IDisposable
    {
        private HttpClient _httpClient;

        public DownloadService()
        {
            _httpClient = new HttpClient();
        }

        public async Task DownloadImageAsync(string imageUrl, string downloadPath)
        {
            byte[] imageBytes = await _httpClient.GetByteArrayAsync(imageUrl);

            if(Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }
   

            string fileName = GenerateUniqueFileName();
            string filePath = Path.Combine(downloadPath, fileName);

            File.WriteAllBytes(filePath, imageBytes);

            Console.WriteLine("Obrázek byl úspěšně stažen a uložen do složky: " + filePath);
        }

        private string GenerateUniqueFileName()
        {
            return Guid.NewGuid().ToString() + ".jpg";
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
