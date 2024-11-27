using InternetShop.UseCases.DTOs.Baskets.Requests.PostAddProductToBasketById;
using MediatR;

namespace InternetShop.UseCases.Commands.Basket.PostAddProductToBasketById;

/// <summary>
/// Команда запроса <see cref="PostAddProductToBasketByIdRequest"/>
/// </summary>
public class PostAddProductToBasketByIdCommand : PostAddProductToBasketByIdRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostAddProductToBasketByIdCommand(PostAddProductToBasketByIdRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
    }
}
