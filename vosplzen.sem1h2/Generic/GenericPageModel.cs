using vosplzen.sem1h2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using vosplzen.sem1h2.Data.Model;
using vosplzen.sem1h2.Generic;



namespace vosplzen.sem1h2.Generic
{
    public class GenericPageModel:PageModel
    {

        internal ApplicationDbContext _context;

        public string Message { get; set; } = String.Empty;

    }
}
