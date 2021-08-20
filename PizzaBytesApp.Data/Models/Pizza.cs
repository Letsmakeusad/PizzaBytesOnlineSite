using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaBytesApp.Data.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Description { get; set; }

      

        [Required]
        [MinLength(20)]
        [MaxLength(2000)]
        public string ImgUrl { get; set; }

     

        [Required]
        [Range(1, double.MaxValue)]       
        public Decimal Price { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
