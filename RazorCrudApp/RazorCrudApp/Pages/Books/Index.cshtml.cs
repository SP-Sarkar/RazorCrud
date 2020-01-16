using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
        
        public void OnGet()
        {
            Books = _context.Books.ToList();
        }


    }
}