using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }

        public Phone Phone { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public List<Order> Orders { get; set; }
    }
}
