using InternetShop.UseCases.DTOs.Products;
using InternetShop.UseCases.DTOs.Users;

namespace InternetShop.UseCases.DTOs.Baskets;
public class BasketDTO
{

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public UserDTO User { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<ProductDTO> Products { get; set; }

    /// <summary>
    /// Полная цена
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public UserStatuses Status { get; set; }
}
