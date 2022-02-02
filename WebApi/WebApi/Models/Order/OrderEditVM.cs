using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class OrderEditVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "You must select one product at least")]
        public List<int> ProductsId { get; set; }
    }
}
