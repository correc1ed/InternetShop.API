using InternetShop.UseCases.DTOs.Baskets.Requests.DeleteProductFromBasketById;
using MediatR;

namespace InternetShop.UseCases.Commands.Basket.DeleteProductFromBasketById;

/// <summary>
/// Команда запроса <see cref="DeleteProductFromBasketByIdRequest"/>
/// </summary>
public class DeleteProductFromBasketByIdCommand : DeleteProductFromBasketByIdRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public DeleteProductFromBasketByIdCommand(Guid id, DeleteProductFromBasketByIdRequest request)
    {
        Id = id;
        ProductId = request.ProductId;
    }
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
}
