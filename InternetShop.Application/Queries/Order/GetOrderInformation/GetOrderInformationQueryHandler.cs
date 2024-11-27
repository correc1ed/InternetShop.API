using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;
using MediatR;

namespace InternetShop.UseCases.Queries.Order.GetOrderInformation;

public class GetOrderInformationQueryHandler : IRequestHandler<GetOrderInformationQuery, GetOrderInfoByIdResponse>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderInformationQueryHandler(
        IOrderRepository orderRepository
    )
    {
        _orderRepository = orderRepository;
    }

    public async Task<GetOrderInfoByIdResponse> Handle(GetOrderInformationQuery request, CancellationToken cancellationToken)
    {
        var response = await _orderRepository.GetOrderInfoByIdAsync(request.Id, cancellationToken);

        return new GetOrderInfoByIdResponse()
        {
            Id = response.Id,
            User = response.User,
            Products = response.Products,
            Status = response.Status,
            CreatedAt = response.CreatedAt,
            DeliveredDate = response.DeliveredDate
        };
    }
}