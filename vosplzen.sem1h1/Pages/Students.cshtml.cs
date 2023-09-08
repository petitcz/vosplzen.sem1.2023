using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h1.Model;

namespace vosplzen.sem1h1.Pages
{
    public class StudentsModel : PageModel
    {

        public List<Student> Students { get; set; }

        public void OnGet()
        {
            Students = new List<Student>();

            Students.Add(
                new Student()
                {
                    Name = "Petr",
                    Lastname = "Boháè",
                    Email = "petr.bohac@codeclimber.cz",
                    Class = "Master"
                });

            Students.Add(
               new Student()
               {
                   Name = "Jaromír",
                   Lastname = "Novák",
                   Email = "jaromir.novak@escroom.cz",
                   Class = "ESC01"
               });

        }
    }
}
