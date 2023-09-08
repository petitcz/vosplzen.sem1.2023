using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h1.Model;
using vosplzen.sem1h1.Services;

namespace vosplzen.sem1h1.Pages
{
    public class StudentsModel : PageModel
    {

        public List<Student> Students { get; set; } = new List<Student>();

        public bool FilterIsOn { get; set; }

        public void OnGet(string orderby = "lastname", string classfilterby = "")
        {
            Students = DataProvider.GetStudents(orderby, classfilterby);

            if (classfilterby.Length > 0)
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
