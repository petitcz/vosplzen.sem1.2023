using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vosplzen.sem1h3cons.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using vosplzen.sem1h3.Data.Model;
    using vosplzen.sem1h3.Services.Interfaces;
    using vosplzen.sem1h3cons.Data;
    using static Azure.Core.HttpHeader;

    public class DataService : IDataService, IDisposable
    {
        private HttpClient _httpClient;
        private ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _httpClient = new HttpClient();
            _context = context;
        }

        public async Task<List<Student>> GetData()
        {
            var list = await _context.Students.ToListAsync();
            return list;
        }
        
        public async Task CreateNewProfile()
        {
            byte[] imageBytes = await _httpClient.GetByteArrayAsync(@"https://thispersondoesnotexist.com/");

            var name = RandomFirstName();
            var lastname = RandomLastName();

            _context.Students.Add(
                new Student()
                {
                    Name = name,
                    LastName = lastname,
                    ImageBlob = imageBytes,
                    Email = RemoveDiacritics(name) + ' ' + RemoveDiacritics(lastname)

                });;

            await _context.SaveChangesAsync();

        }

        private string GenerateUniqueFileName()
        {
            return Guid.NewGuid().ToString() + ".jpg";
        }

        private string RandomFirstName()
        {

            List<string> names = new List<string>
            {
                "Jan",
                "Petr",
                "Marie",
                "Jana",
                "Karel",
                "Eva",
                "Miroslav",
                "Anna",
                "Jiří",
                "Lenka"
            };

            Random rand = new Random();
            int index = rand.Next(names.Count);
            return names[index];
        }

        private string RandomLastName()
        {

            List<string> names = new List<string>
            {
                "Novák",
                "Svoboda",
                "Novotný",
                "Dvořák",
                "Černý",
                "Procházka",
                "Kovář",
                "Němec",
                "Marek",
                "Hájek",
                "Kučera",
                "Bartoš",
                "Král",
                "Veselý",
                "Horák",
                "Urban",
                "Kříž",
                "Šimek",
                "Pospíšil",
                "Kadlec"
            };

            Random rand = new Random();
            int index = rand.Next(names.Count);
            return names[index];
        }

        public static string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
