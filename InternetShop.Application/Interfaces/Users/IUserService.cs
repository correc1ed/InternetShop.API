using InternetShop.UseCases.Commands.User.PostUserLogin;
using InternetShop.UseCases.Commands.User.PostUserRegistration;
using InternetShop.UseCases.Commands.User.PutUserProfile;
using InternetShop.UseCases.Commands.User.PutUserProfileForAdmin;

namespace InternetShop.UseCases.Interfaces.Users;
public interface IUserService
{
    Task RegisterAsync(PostUserRegistrationCommand request, CancellationToken cancellationToken);
    Task<string> AuthorizeAsync(PostUserLoginCommand request, CancellationToken cancellationToken);
    Task UpdateUserByIdAsync(Guid userId, PutUserProfileCommand request, CancellationToken cancellationToken);
    Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminCommand request, CancellationToken cancellationToken);
}
