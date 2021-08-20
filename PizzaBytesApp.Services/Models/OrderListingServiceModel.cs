using PizzaBytesApp.Common.Mapping;
using PizzaBytesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PizzaBytesApp.Services.Models
{
    public class OrderListingServiceModel: IMapFrom<Order>, IHaveCustomMapping
    {
        public int Id { get; set; }
 
        public string ImgUrl { get; set; }
 
        public DateTime OrderedAt { get; set; }

        public decimal TotalPrice { get; set; }
 
        public void ConfigureMapping(Profile mapper)
         => mapper
                .CreateMap<Order, OrderListingServiceModel>()
                .ForMember(o => o.ImgUrl, cfg => cfg.MapFrom(o => o.Pizza.ImgUrl))              
                .ForMember(o => o.TotalPrice, cfg => cfg.MapFrom(o => o.TotalPrice));
    }
}
