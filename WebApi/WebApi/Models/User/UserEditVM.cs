using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.User
{
    public class UserEditVM
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name of the user must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Name of the user must contain 3 letters at least")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Surname of the user must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Surname of the user must contain 3 letters at least")]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Age of the user can't be empty")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Age of the user must contain only numbers")]
        [Range(5, 100, ErrorMessage = "Age of the user must be between 5 and 100")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Phone model of the user can't be empty")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Phone model of the user must contain only latin letters")]
        [MinLength(3, ErrorMessage = "Phone model of the user must contain 3 letters at least")]
        [MaxLength(20)]
        public string PhoneModel { get; set; }
        [Required(ErrorMessage = "Phone number of the user can't be empty")]
        [RegularExpression(@"^[0-9\s]*$", ErrorMessage = "Phone number of the user must contain only numbers")]
        [MinLength(7, ErrorMessage = "Phone number of the user must contain 7 numbers at least")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
