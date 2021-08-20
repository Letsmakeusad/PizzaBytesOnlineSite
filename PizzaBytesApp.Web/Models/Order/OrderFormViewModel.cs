namespace PizzaBytesApp.Web.Models.Order
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using PizzaBytesApp.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrderFormViewModel
    {
        public string ImgUrl { get; set; }

        public string Description { get; set; }

        public string PizzaName { get; set; }

        public int PizzaId { get; set; }

        public string Note { get; set; }

        [Required]
        public string DeliveryAdress { get; set; }

        public decimal PizzaPrice { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public PizzaType Type { get; set; }
         

    }
}
