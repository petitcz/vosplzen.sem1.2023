using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h1.Model;

namespace vosplzen.sem1h1.Pages
{
    public class StudentsModel : PageModel
    {

        public List<Student> Students { get; set; }
        public bool FilterIsOn { get; set; }

        public void OnGet(string orderby = "lastname", string classfilterby = "")
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

            Students.Add(
                  new Student()
                  {
                      Name = "Americo",
                      Lastname = "Vespucci",
                      Email = "americo.vespucci@volny.cz",
                      Class = "Master"
                  });

            Students.Add(
                 new Student()
                 {
                     Name = "Marylin",
                     Lastname = "Monroe",
                     Email = "marylin.monroe@tiscalli.cz",
                     Class = "Master"
                 });


            if (orderby.Equals("lastname"))
            {
                Students = Students.OrderBy(x => x.Lastname).ToList();
            }
            else if (orderby.Equals("name"))
            {
                Students = Students.OrderBy(x => x.Name).ToList();
            }
            else if (orderby.Equals("email"))
            {
                Students = Students.OrderBy(x => x.Email).ToList();
            }
            else if (orderby.Equals("class"))
            {
                Students = Students.OrderBy(x => x.Class).ToList();
            }


            if(classfilterby.Length > 0)
            {
                Students = Students.Where(x => x.Class.Equals(classfilterby)).ToList();
                FilterIsOn = true;
            }
            else
            {
                FilterIsOn = false;
            }

        }
    }
}
