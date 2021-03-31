using AutoMapper;
using MmtDigital.Ecommerce.Entities;

namespace MmtDigital.Ecommerce.OrderTrackerApi
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderId));
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>()
                .ForMember(dest => dest.PriceEach, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.ProductName));
        }
    }
}
