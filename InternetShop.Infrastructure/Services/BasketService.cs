using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Baskets.Requests.PostAddProductToBasketById;
using InternetShop.UseCases.Interfaces.Baskets;

namespace InternetShop.Infrastructure.Services;
public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public BasketService(
        IBasketRepository basketRepository,
        IUserRepository userRepository,
        IProductRepository productRepository)
    {
        _basketRepository = basketRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(PostAddProductToBasketByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        var basket = await _basketRepository.GetByUserIdAsync(user.Id, cancellationToken);


        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CountInStorage = request.CountInStorage,
            Category = request.Category
        };

        if (basket == null)
        {
            basket = new Basket()
            {
                Id = Guid.NewGuid(),
                User = user,
                Products = new List<Product>(),
                TotalPrice = 0,
                Status = 0
            };
        }
        await _productRepository.AddAsync(product);
    }

    public async Task DeleteProductByIdAsync(Guid userId, Guid productId, CancellationToken cancellationToken)
    {
        await _basketRepository.RemoveProduct(userId, productId);
    }
}
