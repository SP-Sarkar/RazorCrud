using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.category
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Category Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            try
            {
                var categoryInDb = await _context.Categories.FindAsync(id);
                if (categoryInDb == null) return NotFound();
                _context.Categories.Remove(categoryInDb);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return NotFound();
            }
        }
    }
}