
namespace PizzaBytesApp.Services.Admin.Models
{
    using PizzaBytesApp.Common.Mapping;
    using PizzaBytesApp.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdminPizzaListingServiceModel : IMapFrom<Pizza>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string ImgUrl { get; set; }


        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}