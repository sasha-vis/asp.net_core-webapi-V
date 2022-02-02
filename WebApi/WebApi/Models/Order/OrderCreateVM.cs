using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class OrderCreateVM
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must select one product at least")]
        public List<int> ProductsId { get; set; }
    }
}
