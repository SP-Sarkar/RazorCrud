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
    public class EditModel : PageModel
    {
        private AppDbContext _context;
        private IHostingEnvironment _environment;

        public EditModel(AppDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Author Author { get; set; }
        [BindProperty]
        public IFormFile ImageUpload { get; set; }


        public void OnGet(int id)
        {
            Author = _context.Authors.Find(id);
        }
        
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var oldAuthor = await _context.Authors.FindAsync(Author.Id);
                if (ImageUpload != null) oldAuthor.Image = Author.Image;
                oldAuthor.Bio = Author.Bio;
                oldAuthor.Website = Author.Website;
                oldAuthor.DOB = Author.DOB;
                oldAuthor.Email = Author.Email;
                oldAuthor.MobileNo = Author.MobileNo;
                oldAuthor.Name = Author.Name;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        private string UploadFile()
        {
            var path = Path.Combine(_environment.WebRootPath, "uploads", ImageUpload.FileName);
            var fileStream = new FileStream(path, FileMode.Create);
            ImageUpload.CopyToAsync(fileStream);
            return ImageUpload.FileName;
        }
    }
}