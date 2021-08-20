using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBytesApp.Data;
using PizzaBytesApp.Data.Models;
using PizzaBytesApp.Services;
using PizzaBytesApp.Services.Models;
using PizzaBytesApp.Web.Infrastructure.Extensions;
using PizzaBytesApp.Web.Models.Order;
using PizzaBytesApp.Web.Models.Pizza;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBytesApp.Web.Controllers
{
    [Authorize(Roles = "Customer,Administrator")]
    public class OrderController: Controller
    {
        private IOrderService orders;
        private IPizzaService pizzas;
        private UserManager<User> userManager;
       

        public OrderController(IOrderService orders, IPizzaService pizzas, UserManager<User> userManager )
        {
           
            this.orders = orders;
            this.pizzas = pizzas;
            this.userManager = userManager;
            
        }


        public async Task<IActionResult> Details(int id)
        {
            var userId = userManager.GetUserId(User);
            

            var order = new OrderDetailsViewModel
            {
                Order = await this.orders.ByIdAsync<OrderDetailsServiceModel>(id)
            };

            if (order.Order == null)
            {
                return NotFound();
            }
            if(userId != order.Order.UserId)
            {
                return NotFound();
            }
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = this.userManager.GetUserId(User);

            //    model.UserIsEnrolledCourse =
            //        await this.courses.StudentIsEnrolledCourseAsync(id, userId);
            //}
            return View(order);
        }


        public async Task<IActionResult> MyOrders()
        {
             var userId = userManager.GetUserId(User);
           
            return this.View(orders.ByUserId(userId));
        }




        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {

           var pizza = await pizzas.ByIdAsync<PizzaDetailsServiceModel>(Id);


            return View(new OrderFormViewModel
            {
                
                PizzaName = pizza.Name,
                PizzaPrice = pizza.Price,
                ImgUrl = pizza.ImgUrl,
                Description = pizza.Description,
                PizzaId = pizza.Id
                

            });     
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = userManager.GetUserId(User);

            var totalPrice = (decimal)(model.Quantity * model.PizzaPrice);

            await this.orders.Create
                (userId,
                 model.Note,
                 model.PizzaId,
                 model.Type,
                 model.Quantity,
                 totalPrice,
                 DateTime.UtcNow,
                 model.DeliveryAdress
                );

            TempData.AddSuccessMessage("Order created. We are on our way!");

            return this.RedirectToAction(nameof(PizzaController.Index), "Pizza");

        }


    }
}
