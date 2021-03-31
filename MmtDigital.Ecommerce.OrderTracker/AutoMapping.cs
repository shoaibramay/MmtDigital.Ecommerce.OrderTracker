using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MmtDigital.Ecommerce.Entities;

namespace MmtDigital.Ecommerce.OrderTrackerApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderViewModel>();
        }
    }
}
