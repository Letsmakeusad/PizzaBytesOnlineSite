using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PizzaBytesApp.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        public string DeliveryAdress { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }


        public PizzaType Type { get; set; }

        public DateTime OrderedAt { get; set; }
 
    }
}
