using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.AppDb;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.author
{
    public class CreateModel : PageModel
    {
        private AppDbContext _context;
        private IHostingEnvironment _environment;

        public CreateModel(AppDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Author Author { get; set; }

        [BindProperty]
        public IFormFile ImageUpload { get; set; }

        public void OnGet()
        {
        }

        private string UploadFile()
        {
            var path = Path.Combine(_environment.WebRootPath, "uploads", ImageUpload.FileName);
            var stream = new FileStream(path, FileMode.Create);
            ImageUpload.CopyToAsync(stream);
            return ImageUpload.FileName;
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid) return Page();
                string uploadedFilePath = UploadFile();
                Author.Image = uploadedFilePath;
                _context.Authors.Add(Author);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}