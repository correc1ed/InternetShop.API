using InternetShop.UseCases.DTOs.Users.Requests.PostUserLogin;
using InternetShop.UseCases.DTOs.Users.Requests.PostUserRegistration;
using InternetShop.UseCases.DTOs.Users.Requests.PutUserProfile;
using InternetShop.UseCases.DTOs.Users.Requests.PutUserProfileForAdmin;

namespace InternetShop.UseCases.Interfaces.Users;
public interface IUserService
{
    Task RegisterAsync(PostUserRegistrationRequest request, CancellationToken cancellationToken);
    Task<string> AuthorizeAsync(PostUserLoginRequest request, CancellationToken cancellationToken);
    Task UpdateUserByIdAsync(Guid userId, PutUserProfileRequest request, CancellationToken cancellationToken);
    Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminRequest request, CancellationToken cancellationToken);
}
