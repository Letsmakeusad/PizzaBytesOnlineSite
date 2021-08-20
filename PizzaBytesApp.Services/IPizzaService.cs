using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBytesApp.Services
{
    public interface IPizzaService
    {
        IEnumerable<PizzaListingServiceModel> All();

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        
    }
}
