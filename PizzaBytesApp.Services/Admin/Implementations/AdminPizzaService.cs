using PizzaBytesApp.Data;
using PizzaBytesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PizzaBytesApp.Services.Admin.Models;
using AutoMapper.QueryableExtensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBytesApp.Services.Admin.Implementations
{
    public class AdminPizzaService : IAdminPizzaService
    {
        private readonly PizzaBytesDbContext db;

        public AdminPizzaService(PizzaBytesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminPizzaListingServiceModel> All()
         => this.db.Pizzas
            .ProjectTo<AdminPizzaListingServiceModel>()
            .ToList();

        public async Task Create(string name, string description, decimal price, string imgUrl)
        {
            var pizza = new Pizza
            {
                Name = name,
                Description = description,
                Price = price,
                ImgUrl = imgUrl
                
            };

            this.db.Add(pizza);
            await this.db.SaveChangesAsync();
        }

        public async Task<Pizza> ById(int id)
        => await this.db
            .Pizzas
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();



         
        
    }
}
