using PizzaBytesApp.Common.Mapping;
using PizzaBytesApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PizzaBytesApp.Services.Models
{
    public class OrderDetailsServiceModel : IMapFrom<Order>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string ImgUrl { get; set; }
 
        public string PizzaName { get; set; }

        public int PizzaId { get; set; }
 
        public string Note { get; set; }

        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveryAdress { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderedAt { get; set; }

        public PizzaType Type { get; set; }

        public void ConfigureMapping(Profile mapper)
          => mapper
                .CreateMap<Order, OrderDetailsServiceModel>()
                .ForMember(o => o.ImgUrl, cfg => cfg.MapFrom(o => o.Pizza.ImgUrl))
                .ForMember(o => o.Note, cfg => cfg.MapFrom(o => o.Note))
                .ForMember(o => o.UserId, cfg => cfg.MapFrom(o => o.UserId))
                .ForMember(o => o.DeliveryAdress, cfg => cfg.MapFrom(o=> o.DeliveryAdress))
                .ForMember(o => o.TotalPrice, cfg => cfg.MapFrom(o => o.TotalPrice));

    }
}
