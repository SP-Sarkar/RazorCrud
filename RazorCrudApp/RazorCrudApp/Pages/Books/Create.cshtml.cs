using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.Books
{
    public class CreateModel : PageModel
    {
        private AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }
        [BindProperty]
        public SelectList Categories { get; set; }

        public void OnGet()
        {
            Categories = new SelectList(_context.Categories.ToList(),"Id","Name");
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid) return Page();
                _context.Books.Add(Book);
                var isAdded = await _context.SaveChangesAsync().ConfigureAwait(true);
                return isAdded > 0 ? RedirectToPage("Index") : RedirectToPage("./Error");
            }
            catch (Exception e)
            {
                return RedirectToPage("./Error");
            }
        }
        
    }
}