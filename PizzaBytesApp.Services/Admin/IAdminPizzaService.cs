using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Services.Admin.Models;

namespace PizzaBytesApp.Services.Admin
{
    public interface IAdminPizzaService
    {
        Task Create(
            string name,
            string description,
            decimal price,
            string imgUrl
            
            );

        IEnumerable<AdminPizzaListingServiceModel> All();

        Task<Pizza> ById(int id);
    }

    
}
