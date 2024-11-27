using InternetShop.UseCases.Interfaces.Users;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PutUserProfileForAdmin;
public class PutUserProfileForAdminCommandHandler : IRequestHandler<PutUserProfileForAdminCommand>
{
    private readonly IUserService _userService;

    public PutUserProfileForAdminCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    public async Task Handle(PutUserProfileForAdminCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserForAdminByIdAsync(request.Id, request, cancellationToken);
    }
}
