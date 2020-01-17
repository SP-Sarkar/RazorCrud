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
        public SelectList Categories { get; set; }
        public SelectList Authors { get; set; }

        public void OnGet()
        {
            Categories = new SelectList(_context.Categories.ToList(),"Id","Name");
            Authors = new SelectList(_context.Authors.ToList(),"Id","Name");
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid) return Page();
                //Book.CategoryId = (int) Categories.Se;
                _context.Books.Add(Book);
                var isAdded = await _context.SaveChangesAsync();
                if (isAdded > 0) return RedirectToPage("Index") ;
                return BadRequest();
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return BadRequest();
            }
        }
        
    }
}