using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(16)]
        public string Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<ProductsOrder> ProductsOrders { get; set; }
    }
}
