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
    public class DetailsModel : PageModel
    {
        private AppDbContext _context;

        public DetailsModel(AppDbContext context)
        {
            _context = context;
        }
        public Book Book { get; set; }
        public void OnGet(int id)
        {
            Book = _context.Books.Find(id);
        }
    }
}