using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hot2.Models
{
    public class Product
    {

        // Read-Only Property for the /slug in the Program.cs file   This Shows the FirstName and the PhoneNumber
        public string Slug => ProductName?.Replace(" ", "-").ToLower();


        // Primary Key
        public int ProductID { get; set; }


        [Required(ErrorMessage = "Please Enter The Product's Name")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Product's Names Must Have At Least 1 to 100 Characters")]
        public string? ProductName { get; set; } = string.Empty;



/*        [Required(ErrorMessage = "Please Enter The Product's Short Description")]*/
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Products's Short Description Must Have At Least 1 to 50 Characters")]
        public string? ProductDescShort { get; set; } = string.Empty;


/*        [Required(ErrorMessage = "Please Enter The Product's Long Description")]*/
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Products's Long Description Must Have At Least 1 to 100 Characters")]
        public string? ProductDescLong { get; set; } = string.Empty;


        [Required(ErrorMessage = "Please Enter The Product's Image")]
        public string? ProductImage { get; set; } = string.Empty;


/*        [Required(ErrorMessage = "Please Enter The Product's Price")]*/
        [Range(1, 100000, ErrorMessage = "Please Enter A Price From $1 to $100000")]
        public decimal? ProductPrice { get; set; }


/*        [Required(ErrorMessage = "Please Enter The Product's Quantity")]*/
        [Range(1, 1000, ErrorMessage = "Please Enter A Quantity From 1 to 1000")]
        public int? ProductQty { get; set; }









        // Foreign Key Property  ~ Entity classes are easier to work with if you add Foreign Key properties that refer to the Primary Key in the related entity class
        [Required(ErrorMessage = "Please Enter a Category")]
        public int CategoryID { get; set; }


        // NAVIGATION PROPERTY
        // Calls in our Category Modal Class To be set to each Product   LINKS BOTH CLASSES TOGETHER
        [ValidateNever]
        public Category Category { get; set; } = null!;




    }
}
