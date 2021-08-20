

namespace PizzaBytesApp.Services.Admin.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PizzaBytesApp.Services.Admin.Models;
    using PizzaBytesApp.Data;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class AdminUserService : IAdminUserService
    {
        private PizzaBytesDbContext db;

        public AdminUserService(PizzaBytesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUserListingServiceModel> All()
        => this.db.Users
            .ProjectTo<AdminUserListingServiceModel>()
            .ToList();

        public IEnumerable<AdminUserOrderListingServiceModel> OrderByUserId(string id)
        => this.db.Orders
            .Where(u => u.UserId == id)      
            .ProjectTo<AdminUserOrderListingServiceModel>()
            .ToList();

        
    }
}
