using InternetShop.Domain.Interfaces.Repository;
using InternetShop.Infrastructure.Persistence.Repository;
using InternetShop.Infrastructure.Services;
using InternetShop.Infrastructure.Services.Jwt;
using InternetShop.UseCases.Interfaces.Baskets;
using InternetShop.UseCases.Interfaces.Jwt;
using InternetShop.UseCases.Interfaces.Orders;
using InternetShop.UseCases.Interfaces.Products;
using InternetShop.UseCases.Interfaces.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace InternetShop.Infrastructure.Extensions.DependencyInjection;
public static class InternetShopExtensions
{
    public static IServiceCollection AddInternetShop(this IServiceCollection services)
    {
        services.TryAddScoped<IUserService, UserService>();
        services.TryAddScoped<IOrderService, OrderService>();
        services.TryAddScoped<IBasketService, BasketService>();
        services.TryAddScoped<IProductService, ProductService>();

        services.TryAddScoped<IBasketRepository, BasketRepository>();
        services.TryAddScoped<IOrderRepository, OrderRepository>();
        services.TryAddScoped<IUserRepository, UserRepository>();
        services.TryAddScoped<IProductRepository, ProductRepository>();

        services.TryAddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}
