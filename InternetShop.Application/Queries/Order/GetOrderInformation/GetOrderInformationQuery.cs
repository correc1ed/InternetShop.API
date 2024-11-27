using InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;
using MediatR;

namespace InternetShop.UseCases.Queries.Order.GetOrderInformation;

/// <summary>
/// Команда запроса <see cref="GetOrderInformationRequest"/>
/// </summary>
public class GetOrderInformationQuery : IRequest<GetOrderInfoByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetOrderInformationQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
