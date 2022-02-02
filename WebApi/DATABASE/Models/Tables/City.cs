using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<User> Users { get; set; }
    }
}
