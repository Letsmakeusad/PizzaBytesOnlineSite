
namespace PizzaBytesApp.Web.Areas.Admin.Models.Pizzas
{
    using PizzaBytesApp.Data.Models;
    using System;

    public class DeletePizzaFormModel
    {
        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public string Description { get; set; }
 
        public string ImgUrl { get; set; }

        public PizzaType Type { get; set; }

       
        public Decimal Price { get; set; }
    }
}
