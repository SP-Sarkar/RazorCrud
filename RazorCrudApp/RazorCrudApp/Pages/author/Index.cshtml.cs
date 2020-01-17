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
    public class IndexModel : PageModel
    {
        private AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Author Author { get; set; }

        public IEnumerable<Author> Authors { get; set; }
        public void OnGet()
        {
            Authors = _context.Authors.ToList();
        }
    }
}