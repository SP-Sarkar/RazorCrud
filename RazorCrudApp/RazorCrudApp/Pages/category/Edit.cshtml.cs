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
    public class EditModel : PageModel
    {
        private AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _context.Categories.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var oldCategory = await _context.Categories.FindAsync(Category.Id);
            if (oldCategory == null) return BadRequest();
            oldCategory.Name = Category.Name;
            var isUpdated = await _context.SaveChangesAsync();
            if (isUpdated > 0) return RedirectToPage("Index");
            return BadRequest();
        }

    }
}