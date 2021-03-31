using AutoMapper;
using MmtDigital.Ecommerce.Entities;

namespace MmtDigital.Ecommerce.OrderTrackerApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(dest => dest.PriceEach, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.ProductName));
        }
    }
}
