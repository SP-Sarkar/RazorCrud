using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.category
{
    public class DetailsModel : PageModel
    {
        private AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (Category != null) Category.Books = _context.Books.Where(b => b.CategoryId == Category.Id).ToList();
        }
    }
}