using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBytesApp.Services
{
    public interface IOrderService
    {
        Task Create(
           string userId,
           string note,
           int pizzaId,
           PizzaType type,
           int quantity,
           decimal TotalPrice,
           DateTime orderedAt,
           string deliveryAdress
           );

        Task GetPizzaById(int id);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        IEnumerable<OrderListingServiceModel> ByUserId(string id);
    }
}
