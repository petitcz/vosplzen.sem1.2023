using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h1.Model;
using vosplzen.sem1h1.Services;

namespace vosplzen.sem1h1.Pages
{
    public class StudentsModel : PageModel
    {

        [BindProperty]
        public StudentFilterDto Filter { get; set; } = new StudentFilterDto();

        public List<Student> Students { get; set; } = new List<Student>();
        

        public void OnGet(string orderby = "lastname", string classfilterby = "")
        {
            Filter = new StudentFilterDto()
            {
                OrderBy = orderby,
                ClassFilterBy = classfilterby
            };

            Students = DataProvider.GetStudents(Filter);

        }

        public IActionResult OnPost()
        {
            Students = DataProvider.GetStudents(Filter);     
            return Page();
        }

    }
}
