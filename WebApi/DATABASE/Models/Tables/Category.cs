﻿using System.ComponentModel.DataAnnotations;

namespace DATABASE
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
