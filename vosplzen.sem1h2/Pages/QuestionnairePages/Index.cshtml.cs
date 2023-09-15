


using vosplzen.sem1h2.Data;
using vosplzen.sem1h2.Data.Model;
using vosplzen.sem1h2.Generic;

namespace vosplzen.sem1h2.Pages.QuestionnairePages
{
    public class IndexModel : GenericPageModel
    {            
        public List<Questionnaire> Questionnaires { get; set; } = new List<Questionnaire>(); 

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Questionnaires = _context.Questionnaires.ToList();
        }
    }
}
