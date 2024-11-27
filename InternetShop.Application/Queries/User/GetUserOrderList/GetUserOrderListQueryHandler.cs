using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.DTOs.Users.Responses.GetOrderList;
using MediatR;

namespace InternetShop.UseCases.Queries.User.GetUserOrderList;
public class GetUserOrderListQueryHandler : IRequestHandler<GetUserOrderListQuery, GetUserOrderListResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserOrderListQueryHandler(
        IUserRepository userRepository
    )
    {
        _userRepository = userRepository;
    }
    async Task<GetUserOrderListResponse> IRequestHandler<GetUserOrderListQuery, GetUserOrderListResponse>.Handle(GetUserOrderListQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetOrderListAsync(request.Id, cancellationToken);

        return new GetUserOrderListResponse()
        {
            Orders = response
        };
    }
}


