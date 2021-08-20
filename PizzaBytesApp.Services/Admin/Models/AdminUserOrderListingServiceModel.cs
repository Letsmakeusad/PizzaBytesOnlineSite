using PizzaBytesApp.Common.Mapping;
using PizzaBytesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PizzaBytesApp.Services.Admin.Models
{


    public class AdminUserOrderListingServiceModel : IMapFrom<Order>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string PizzaName { get; set; }

        public DateTime OrderedAt { get; set; }

        public string UserName { get; set; }

        public string DeliveringTo { get; set; }

        public decimal TotalPrice { get; set; }

        public void ConfigureMapping(Profile mapper)
         => mapper
                .CreateMap<Order, AdminUserOrderListingServiceModel>()
                .ForMember(o => o.DeliveringTo, cfg => cfg.MapFrom(o => o.DeliveryAdress))
                .ForMember(o => o.OrderedAt, cfg => cfg.MapFrom(o => o.OrderedAt))
                .ForMember(o=> o.PizzaName, cfg=> cfg.MapFrom(o=> o.Pizza.Name))
                .ForMember(o => o.UserName, cfg => cfg.MapFrom(o => o.User.Name))
                .ForMember(o => o.TotalPrice, cfg => cfg.MapFrom(o => o.TotalPrice));


    }

}
