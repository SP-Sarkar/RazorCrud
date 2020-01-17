using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.author
{
    public class _AuthorBooksModel : PageModel
    {
//        private AppDbContext _context;
//
//        public _AuthorBooksModel(AppDbContext context)
//        {
//            _context = context;
//        }

        [BindProperty]
        public IEnumerable<Book> Books { get; set; }
        
        public void OnGet()
        {

        }
    }
}