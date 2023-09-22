using vosplzen.sem1h3cons.Services;

namespace vosplzen.sem1h3cons
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            using (var downloader = new DownloadService())
            {
                for(int i = 0; i < 10;i++)
                {
                    await downloader.DownloadImageAsync("https://thispersondoesnotexist.com/", @"C:\_temp\ThisPersonDoesNotExist\");
                }
                
            }

                

        }
    }
}