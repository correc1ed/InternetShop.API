using InternetShop.CompositionRoot.Extensions.DependencyInjection;
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
using Microsoft.AspNetCore.Authentication.Cookies;
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
			var assemblies = new[]
			{
				Assembly.GetExecutingAssembly(),
				typeof(DeleteProductFromBasketByIdCommand).Assembly,
				typeof(PostAddProductToBasketByIdCommand).Assembly,
				typeof(GetOrderInformationQuery).Assembly,
				typeof(PostOrderCommand).Assembly,
				typeof(PutOrderStatusCommand).Assembly,
				typeof(PostProductCommand).Assembly,
				typeof(PutProductCommand).Assembly,
				typeof(PostUserLoginCommand).Assembly,
				typeof(PostUserRegistrationCommand).Assembly,
				typeof(PutUserProfileCommand).Assembly
			};

			cfg.RegisterServicesFromAssemblies(assemblies);
		});

		builder.Services.AddEndpointsApiExplorer();

		builder.Services.AddSwaggerGen();

		builder.Services.AddServicesAndRepositories();

		builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.LoginPath = "/login"; // ”кажите путь к странице входа
				options.LogoutPath = "/logout"; // ”кажите путь к странице выхода
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // ¬рем€ жизни Cookie
			});

		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("AdminPolicy", policy => policy.RequireRole("true", "false"));

			options.AddPolicy("UserPolicy", policy => policy.RequireRole("false"));
		});

		builder.Services.AddDbContext<Infrastructure.EfContext>(options =>
			options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthentication();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
