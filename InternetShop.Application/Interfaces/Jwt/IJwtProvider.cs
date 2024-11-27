using InternetShop.Domain.Entities;

namespace InternetShop.UseCases.Interfaces.Jwt;
public interface IJwtProvider
{
    public string GenerateToken(User user);
}
