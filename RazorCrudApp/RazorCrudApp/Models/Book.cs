using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCrudApp.Models
{
    public class Book
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Book ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [ForeignKey("Category")]
        [Required]
        [Display(Name="Category Name")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey("Author")]
        [Required]
        [Display(Name = "Author Name")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
