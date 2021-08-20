using PizzaBytesApp.Common.Mapping;
using PizzaBytesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBytesApp.Services.Models
{
    public class PizzaListingServiceModel: IMapFrom<Pizza>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
