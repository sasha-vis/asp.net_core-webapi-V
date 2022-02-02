using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ProductsOrder> ProductsOrders { get; set; }
    }
}
