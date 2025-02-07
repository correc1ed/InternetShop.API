using AutoMapper;
using InternetShop.Domain.Entities;
using InternetShop.UseCases.DTOs.Baskets;
using InternetShop.UseCases.DTOs.Orders;
using InternetShop.UseCases.DTOs.Products;
using InternetShop.UseCases.DTOs.Users;

namespace InternetShop.UseCases.Mapping;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<User, UserDTO>();
		CreateMap<UserDTO, User>();

		CreateMap<Product, ProductDTO>();
		CreateMap<ProductDTO, Product>();

		CreateMap<Order, OrderDTO>();
		CreateMap<OrderDTO, Order>();

		CreateMap<Basket, BasketDTO>();
		CreateMap<BasketDTO, Basket>();
	}
}
