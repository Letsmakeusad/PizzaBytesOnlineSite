namespace PizzaBytesApp.Web.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PizzaBytesApp.Data.Models;

    public class AddUserOrderFormModel
    {
 
        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public string UserId { get; set; }
 
        public decimal TotalPrice { get; set; }

        public string Note { get; set; }

        public DateTime OrderedAt { get; set; }

    }
}
