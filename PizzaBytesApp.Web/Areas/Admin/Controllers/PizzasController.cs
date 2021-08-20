namespace PizzaBytesApp.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PizzaBytesApp.Data;
    using PizzaBytesApp.Services.Admin;
    using PizzaBytesApp.Web.Areas.Admin.Models.Pizzas;
    using PizzaBytesApp.Web.Controllers;
    using PizzaBytesApp.Web.Infrastructure.Extensions;
    using System.Threading.Tasks;
    using static WebConstants;


    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class PizzasController : Controller
    {
        private IAdminPizzaService pizzas;
        private readonly PizzaBytesDbContext db;

        public PizzasController(IAdminPizzaService pizzas, PizzaBytesDbContext db)
        {
            this.pizzas = pizzas;
            this.db = db;
        }

        public IActionResult Index()
         => View(this.pizzas.All());

        public async Task<IActionResult>  Create()
        {
            return View(new PizzaFormModel
            {

            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(PizzaFormModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

               await this.pizzas.Create(
                model.Name,
                model.Description,
                model.Price,
                model.ImgUrl);

            TempData.AddSuccessMessage("Pizza Added Successfully To The Menu!");

            return RedirectToAction(nameof(PizzasController.Index), "Pizzas", new { area = "Admin" });

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.db.Pizzas.FindAsync(id);

            if(model == null)
            {
                return NotFound();
            }

            return View(new PizzaFormModel
            {
                Id = model.Id,
                Price = model.Price,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PizzaFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var pizza = await this.pizzas.ById(model.Id);

            pizza.Price = model.Price;
            pizza.Description = model.Description;
            pizza.ImgUrl = model.ImgUrl;
            pizza.Name = model.Name;

            this.db.SaveChanges();

            TempData.AddSuccessMessage("Pizza Editted Successfully!");

            return RedirectToAction(nameof(PizzasController.Index));
            
            

        }


        public async Task<IActionResult> Delete(int id)
        {
            var pizza = await this.pizzas.ById(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return View(new DeletePizzaFormModel
            {
                Id = pizza.Id,
                Price = pizza.Price,
                Description = pizza.Description,
                ImgUrl = pizza.ImgUrl,
                Name = pizza.Name,

            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePizzaFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var pizza = await this.pizzas.ById(model.Id);

            this.db.Remove(pizza);
            this.db.SaveChanges();

            TempData.AddSuccessMessage("Pizza Deleted Successfully From The Menu!");

            return RedirectToAction(nameof(PizzasController.Index));



        }







    }
}
