using InternetShop.UseCases.DTOs.Users.Responses.GetOrderList;
using MediatR;

namespace InternetShop.UseCases.Queries.User.GetUserOrderList;
public class GetUserOrderListQuery : IRequest<GetUserOrderListResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public GetUserOrderListQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}
