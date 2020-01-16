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

        public async Task<IActionResult> OnPostDelete(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (book == null) return BadRequest();
                _context.Books.Remove(book);
                var isDeleted = await _context.SaveChangesAsync();
                if (isDeleted > 0) return RedirectToPage("Index");
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}