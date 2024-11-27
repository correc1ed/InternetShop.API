using InternetShop.UseCases.Interfaces.Users;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PutUserProfile;

public class PutUserProfileCommandHandler : IRequestHandler<PutUserProfileCommand>
{
    private readonly IUserService _userService;

    public PutUserProfileCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PutUserProfileCommand>.Handle(PutUserProfileCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUserByIdAsync(request.Id, request, cancellationToken);
    }
}