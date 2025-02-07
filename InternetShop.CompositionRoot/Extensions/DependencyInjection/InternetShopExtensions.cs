using InternetShop.Domain.Interfaces.Repository;
using InternetShop.Infrastructure.Persistence.Repository;
using InternetShop.Infrastructure.Services;
using InternetShop.UseCases.Interfaces.Baskets;
using InternetShop.UseCases.Interfaces.Orders;
using InternetShop.UseCases.Interfaces.Products;
using InternetShop.UseCases.Interfaces.Users;
using InternetShop.UseCases.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace InternetShop.CompositionRoot.Extensions.DependencyInjection;
public static class InternetShopExtensions
{
	public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IOrderService, OrderService>();
		services.AddScoped<IBasketService, BasketService>();
		services.AddScoped<IProductService, ProductService>();

		services.AddScoped<IBasketRepository, BasketRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();

		services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

		return services;
	}
}
