using InternetShop.UseCases.DTOs.Orders.Requests.PostOrder;
using MediatR;

namespace InternetShop.UseCases.Commands.Order.PostOrder;

/// <summary>
/// Команда запроса <see cref="PostOrderRequest"/>
/// </summary>
public class PostOrderCommand : PostOrderRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostOrderCommand(PostOrderRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
    }
}
