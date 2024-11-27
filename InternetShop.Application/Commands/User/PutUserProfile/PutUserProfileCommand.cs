using InternetShop.UseCases.DTOs.Users.Requests.PutUserProfile;
using MediatR;

namespace InternetShop.UseCases.Commands.User.PutUserProfile;

/// <summary>
/// Команда запроса <see cref="PutUserProfileRequest"/>
/// </summary>
public class PutUserProfileCommand : PutUserProfileRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUserProfileCommand(Guid id, PutUserProfileRequest request)
    {
        Id = id;
        Name = request.Name;
        Email = request.Email;
        Password = request.Password;
    }

    /// <summary>
    /// Идентификаторв
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}
