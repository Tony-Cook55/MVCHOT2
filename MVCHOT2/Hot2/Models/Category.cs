using System.ComponentModel.DataAnnotations;

namespace Hot2.Models
{
    public class Category
    {


        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Category Name Is Required")]
        public string CategoryName { get; set; } = string.Empty;




    }
}
