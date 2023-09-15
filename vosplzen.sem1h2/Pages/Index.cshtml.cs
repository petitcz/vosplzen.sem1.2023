using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Data.Model;

namespace vosplzen.sem1h2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Questionnaire Questionnaire { get; set; } = new Questionnaire();

        public string Message { get; set; } = String.Empty;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            Questionnaire.Created = DateTime.Now;

            Message = $"Děkujeme za vyplnění dotazníku, Vaše hodnocení je: {Questionnaire.Rating}/5. Hodnoceno {Questionnaire.Created.ToString("dd.MM.yyyy H:m")}";
            
            Questionnaire = new Questionnaire();

            ModelState.Clear();
            
            return Page();
        }

        public void OnGet()
        {

        }
    }
}