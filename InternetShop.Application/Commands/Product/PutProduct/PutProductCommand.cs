using InternetShop.UseCases.DTOs.Products.Requests.PutProduct;
using MediatR;

namespace InternetShop.UseCases.Commands.Product.PutProduct;

/// <summary>
/// Команда запроса <see cref="PutProductRequest"/>
/// </summary>
public class PutProductCommand : PutProductRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutProductCommand(Guid id, PutProductRequest request)
    {
        Id = id;
        Name = request.Name;
        Description = request.Description;
        Price = request.Price;
        CountInStorage = request.CountInStorage;
        Category = request.Category;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество на складе
    /// </summary>
    public int CountInStorage { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public string Category { get; set; }
}
