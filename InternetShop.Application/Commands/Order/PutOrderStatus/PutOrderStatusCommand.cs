using InternetShop.Domain.Entities.Enums;
using InternetShop.UseCases.DTOs.Orders.Requests.PutOrderStatus;
using MediatR;

namespace InternetShop.UseCases.Commands.Order.PutOrderStatus;

/// <summary>
/// Команда запроса <see cref="PutOrderStatusRequest"/>
/// </summary>
public class PutOrderStatusCommand : PutUpdateOrderStatusRequest, IRequest
{

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutOrderStatusCommand(Guid id, PutUpdateOrderStatusRequest request)
            : base(request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Id = id;
        Status = request.Status;
    }
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }

}
