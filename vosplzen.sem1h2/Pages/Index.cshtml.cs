using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vosplzen.sem1h2.Data;
using vosplzen.sem1h2.Data.Model;
using vosplzen.sem1h2.Generic;

namespace vosplzen.sem1h2.Pages
{
    public class IndexModel : GenericPageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Questionnaire Questionnaire { get; set; } = new Questionnaire();


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }            

            Questionnaire.Created = DateTime.Now;

            _context.Questionnaires.Add(Questionnaire);
            _context.SaveChanges();

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