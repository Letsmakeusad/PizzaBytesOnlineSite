using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaBytesApp.Data;
using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBytesApp.Services.Implementations
{
    public class PizzaService : IPizzaService
    {
        private readonly PizzaBytesDbContext db;

        public PizzaService(PizzaBytesDbContext db)
        {
            this.db = db;
        }

       

        public IEnumerable<PizzaListingServiceModel> All()
         => this.db.Pizzas
            .ProjectTo<PizzaListingServiceModel>()
            .ToList();


        public async Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
       => await this.db
           .Pizzas
           .Where(c => c.Id == id)        
           .ProjectTo<TModel>()
           .FirstOrDefaultAsync();

         
        
    }
}
