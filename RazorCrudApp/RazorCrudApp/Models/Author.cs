using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCrudApp.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name="Author Name")]
        [StringLength(200,ErrorMessage = "Author name should not be more than 200 characters")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage = "Email Id is not Valid")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
        [DataType(DataType.Date,ErrorMessage = "Date of birth is not valid")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile No is not valid")]
        [Display(Name = "Mobile No")]
        [MinLength(10)][MaxLength(10)]
        [StringLength(10, ErrorMessage = "Mobile No should not be more than 200 characters")]
        public string MobileNo { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Website  is not valid")]
        [Display(Name = "Website")]
        [StringLength(100, ErrorMessage = "Website should not be more than 200 characters")]
        public string Website { get; set; }

        [Display(Name = "Author Bio")]
        [StringLength(2000, ErrorMessage = "Author Bio should not be more than 200 characters")]
        public string Bio { get; set; }

        [Display(Name = "Author Avatar")]
        [DataType(DataType.ImageUrl)]
        [StringLength(200, ErrorMessage = "Author Bio should not be more than 200 characters")]
        public string Image { get; set; }


        public virtual IEnumerable<Book> Books { get; set; }
    }
}
