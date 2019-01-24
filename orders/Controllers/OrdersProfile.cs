using AutoMapper;

namespace orders
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(s => s.Product.Id))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(s => s.Product.Name));
        }
    }
}