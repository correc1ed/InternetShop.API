using InternetShop.UseCases.Interfaces.Users;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PostUserRegistration;

public class PostUserRegistrationCommandHandler : IRequestHandler<PostUserRegistrationCommand>
{
    private readonly IUserService _userService;

    public PostUserRegistrationCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PostUserRegistrationCommand>.Handle(PostUserRegistrationCommand request, CancellationToken cancellationToken)
    {
        await _userService.RegisterAsync(request, cancellationToken);
    }
}