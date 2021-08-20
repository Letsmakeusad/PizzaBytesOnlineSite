namespace PizzaBytesApp.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using PizzaBytesApp.Data.Models;
    using PizzaBytesApp.Data;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly PizzaBytesDbContext db;
        private readonly UserManager<User> userManager;


        public UserService(PizzaBytesDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

         
    }
}
