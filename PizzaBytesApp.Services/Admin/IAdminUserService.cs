namespace PizzaBytesApp.Services.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();

        IEnumerable<AdminUserOrderListingServiceModel> OrderByUserId(string id);
    }
}
