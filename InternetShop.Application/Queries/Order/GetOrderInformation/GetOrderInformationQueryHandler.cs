using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;
using MediatR;

namespace InternetShop.UseCases.Queries.Order.GetOrderInformation;

public class GetOrderInformationQueryHandler : IRequestHandler<GetOrderInformationQuery, GetOrderInfoByIdResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public GetOrderInformationQueryHandler(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IUserRepository userRepository
    )
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<GetOrderInfoByIdResponse> Handle(GetOrderInformationQuery request, CancellationToken cancellationToken)
    {
        var response = await _orderRepository.GetOrderInfoByIdAsync(request.Id, cancellationToken);

        var user = await _userRepository.GetByIdAsync(response.User.Id);

        List<Product> products = new List<Product>();

        foreach (var product in response.Products)
        {
            var productObject = await _productRepository.GetByIdAsync(product);
            products.Add(productObject);
        }

        return new GetOrderInfoByIdResponse()
        {
            Id = response.Id,
            User = user,
            Products = products,
            Status = response.Status,
            CreatedAt = response.CreatedAt,
            DeliveredDate = response.DeliveredDate
        };
    }
}