using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.author
{
    public class DetailsModel : PageModel
    {
        private AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; }

        public void OnGet(int id)
        {
            Author = _context.Authors.Include(b => b.Books).FirstOrDefault(a => a.Id == id);
        }
    }
}