using InternetShop.UseCases.Interfaces.Users;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PostUserLogin;
public class PostUserLoginCommandHandler : IRequestHandler<PostUserLoginCommand>
{
    private readonly IUserService _userService;

    public PostUserLoginCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }
    async Task IRequestHandler<PostUserLoginCommand>.Handle(PostUserLoginCommand request, CancellationToken cancellationToken)
    {
        await _userService.AuthorizeAsync(request, cancellationToken);
    }
}
