using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
