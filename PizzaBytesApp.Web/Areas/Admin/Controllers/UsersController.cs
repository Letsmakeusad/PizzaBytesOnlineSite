namespace PizzaBytesApp.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PizzaBytesApp.Services.Admin;
    using PizzaBytesApp.Web.Areas.Admin.Models.User;
    using System.Threading.Tasks;
    using static WebConstants;

    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class UsersController : Controller
    {
        private readonly IAdminUserService users;

        public UsersController(IAdminUserService users)
        {
            this.users = users;
        }

        public IActionResult Index()
        => View(this.users.All());

        public async Task<IActionResult> Orders(string Id)
        {
            
            return this.View(users.OrderByUserId(Id));
        }

    }
    
}
