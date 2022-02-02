using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CategoryEditVM
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of category can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "The name of category must contain only latin letters")]
        [MinLength(3, ErrorMessage = "The name of category must containt 3 letters at least")]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
