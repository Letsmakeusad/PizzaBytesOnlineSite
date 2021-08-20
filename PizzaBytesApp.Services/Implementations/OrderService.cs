using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Data;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PizzaBytesApp.Services.Models;

namespace PizzaBytesApp.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly PizzaBytesDbContext db;

        public OrderService(PizzaBytesDbContext db)
        {
            this.db = db;
        }

        public async Task GetPizzaById(int id)
            =>  await this.db.Pizzas.FindAsync(id);

       

        public async Task Create(
            string userId, 
            string note,
            int pizzaId,
            PizzaType type, 
            int quantity,
            decimal TotalPrice, 
            DateTime orderedAt,
            string deliveryAdress)
        {

            var order = new Order
            {
                UserId = userId,
                PizzaId = pizzaId,
                Pizza = db.Pizzas.Find(pizzaId),
                User = db.Users.Find(userId),
                Note = note,
                Type = type,
                Quantity = quantity,
                TotalPrice = TotalPrice,
                OrderedAt = DateTime.UtcNow,
                DeliveryAdress = deliveryAdress
            };

            this.db.Add(order);

            await this.db.SaveChangesAsync();
        }

        public Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
        => this.db
            .Orders
            .Where(c => c.Id == id)
            .ProjectTo<TModel>()
            .FirstOrDefaultAsync();

        public IEnumerable<OrderListingServiceModel> ByUserId(string id)
          => this.db.Orders
            .Where(o=> o.UserId == id)
            .ProjectTo<OrderListingServiceModel>()
            .ToList();



    }
}
