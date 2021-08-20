using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaBytesApp.Services;
using PizzaBytesApp.Services.Models;
using PizzaBytesApp.Web.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBytesApp.Web.Controllers
{
    
    [Authorize(Roles = "Customer,Administrator")]
    public class PizzaController : Controller
    {
        private IPizzaService pizzas;

        public PizzaController(IPizzaService pizzas)
        {
            this.pizzas = pizzas;
        }

        public IActionResult Index()
          => View(this.pizzas.All());

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var pizza = new PizzaDetailsViewModel
            {
                Pizza = await this.pizzas.ByIdAsync<PizzaDetailsServiceModel>(id)
            };

            if (pizza.Pizza == null)
            {
                return NotFound();
            }
            //if (User.Identity.IsAuthenticated)
            //{
            //    var userId = this.userManager.GetUserId(User);

            //    model.UserIsEnrolledCourse =
            //        await this.courses.StudentIsEnrolledCourseAsync(id, userId);
            //}
            return View(pizza);
        }
        
        public IActionResult DetailsOrder(int id)
        {

            return this.RedirectToAction(nameof(OrderController.Create), "Order", new { id });
            //return this.RedirectToAction(nameof(PizzaController.Index));
        }
    }
}
