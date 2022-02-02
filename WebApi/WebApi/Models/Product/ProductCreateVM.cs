using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Product
{
    public class ProductCreateVM
    {
        [Required(ErrorMessage = "Name of the product can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "The name of product must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Name of the product must contain 3 letters at least")]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description of the product can't be empty")]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Description of the product must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Description of the product must contain 3 letters at least")]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price of the product can't be empty")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Price of the product must contain only numbers")]
        public string Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
