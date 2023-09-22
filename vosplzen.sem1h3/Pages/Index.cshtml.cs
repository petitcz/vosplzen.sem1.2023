using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using vosplzen.sem1h3.Data.Model;
using vosplzen.sem1h3.Services.Interfaces;

namespace vosplzen.sem1h3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDataService _dataService;

        public List<Student> Students { get; set; } = new List<Student>();

        [BindProperty]
        public int IdToDelete { get; set; } = 0;

        public IndexModel(ILogger<IndexModel> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public async Task<IActionResult> OnGet()
        {
            return await Reload();
        }
        public async Task<IActionResult> OnPostCreate()
        {

            await _dataService.CreateNewProfile();
            return await Reload();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _dataService.DeleteStudent(IdToDelete);
            return await Reload();
        }

        public async Task<IActionResult> Reload()
        {
            Students = await _dataService.GetData();
            return Page();
        }


    }
}