using InternetShop.UseCases.DTOs.Products.Requests.PostProduct;
using MediatR;

namespace InternetShop.UseCases.Commands.Product.PostProduct;

/// <summary>
/// Команда запроса <see cref="PostProductRequest"/>
/// </summary>
public class PostProductCommand : PostProductRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostProductCommand(PostProductRequest request)
            : base(request) { }
}
