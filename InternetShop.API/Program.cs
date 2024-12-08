using InternetShop.Infrastructure;
using InternetShop.Infrastructure.Extensions.DependencyInjection;
using InternetShop.Infrastructure.Services.Jwt;
using InternetShop.UseCases.Commands.Basket.DeleteProductFromBasketById;
using InternetShop.UseCases.Commands.Basket.PostAddProductToBasketById;
using InternetShop.UseCases.Commands.Order.PostOrder;
using InternetShop.UseCases.Commands.Order.PutOrderStatus;
using InternetShop.UseCases.Commands.Product.PostProduct;
using InternetShop.UseCases.Commands.Product.PutProduct;
using InternetShop.UseCases.Commands.User.PostUserLogin;
using InternetShop.UseCases.Commands.User.PostUserRegistration;
using InternetShop.UseCases.Commands.User.PutUserProfile;
using InternetShop.UseCases.Queries.Order.GetOrderInformation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternetShop.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.RegisterServicesFromAssembly(typeof(DeleteProductFromBasketByIdCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostAddProductToBasketByIdCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(GetOrderInformationQuery).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostOrderCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutOrderStatusCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostProductCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutProductCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostUserLoginCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PostUserRegistrationCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(PutUserProfileCommand).Assembly);
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

        builder.Services.AddSwaggerGen();

        builder.Services.AddInternetShop();

        builder.Services.AddDbContext<EfContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

         app.UseHttpsRedirection();

          app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
