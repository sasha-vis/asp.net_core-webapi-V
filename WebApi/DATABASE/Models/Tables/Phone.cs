using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
