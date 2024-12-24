using InternetShop.UseCases.DTOs.Users;
using InternetShop.UseCases.Interfaces.Users;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PostUserLogin;
public class PostUserLoginCommandHandler : IRequestHandler<PostUserLoginCommand, UserDTO>
{
    private readonly IUserService _userService;

    public PostUserLoginCommandHandler(
        IUserService userService
    )
    {
        _userService = userService;
    }

    public async Task<UserDTO> Handle(PostUserLoginCommand request, CancellationToken cancellationToken)
    { 
        var result = await _userService.AuthorizeAsync(request, cancellationToken);
        return result;
    }
}
