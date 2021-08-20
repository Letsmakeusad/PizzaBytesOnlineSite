
namespace PizzaBytesApp.Web.Areas.Admin.Models.Pizzas
{
    using PizzaBytesApp.Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PizzaFormModel
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

        public PizzaType Type { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public Decimal Price { get; set; }

        


    }
}
