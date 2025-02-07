using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.Commands.Product.PostProduct;
using InternetShop.UseCases.Commands.Product.PutProduct;
using InternetShop.UseCases.Interfaces.Products;

namespace InternetShop.Infrastructure.Services;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(
        IProductRepository productRepository
    )
    {
        _productRepository = productRepository;
    }
    public async Task PostAddProductAsync(PostProductCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

		if (string.IsNullOrWhiteSpace(request.Name))
		{
			throw new ArgumentException("Название товара не может быть пустым.", nameof(request.Name));
		}

		if (request.Price <= 0)
		{
			throw new ArgumentException("Цена товара должна быть больше нуля.", nameof(request.Price));
		}

		if (request.CountInStorage < 0)
		{
			throw new ArgumentException("Количество товара на складе не может быть отрицательным.", nameof(request.CountInStorage));
		}

		if (string.IsNullOrWhiteSpace(request.Category))
		{
			throw new ArgumentException("Категория товара не может быть пустой.", nameof(request.Category));
		}

		var product = Product.Add(request.Name, request.Description, request.Price, request.CountInStorage, request.Category);

        await _productRepository.AddAsync(product);
    }
    public async Task PutUpdateProductInfoAsync(Guid id, PutProductCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
        {
            throw new Exception("Товара с данным идентификатором не существует или вы не правильно его указали");
        }

		if (string.IsNullOrWhiteSpace(request.Name))
		{
			throw new ArgumentException("Название товара не может быть пустым.", nameof(request.Name));
		}

		if (request.Price <= 0)
		{
			throw new ArgumentException("Цена товара должна быть больше нуля.", nameof(request.Price));
		}

		if (request.CountInStorage < 0)
		{
			throw new ArgumentException("Количество товара на складе не может быть отрицательным.", nameof(request.CountInStorage));
		}

		if (string.IsNullOrWhiteSpace(request.Category))
		{
			throw new ArgumentException("Категория товара не может быть пустой.", nameof(request.Category));
		}

		var updateProduct = new Product
        {
            Id = product.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CountInStorage = request.CountInStorage,
            Category = request.Category
        };

        await _productRepository.UpdateAsync(updateProduct);
    }
}
