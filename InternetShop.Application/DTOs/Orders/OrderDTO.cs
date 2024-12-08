using InternetShop.UseCases.DTOs.Products;
using InternetShop.UseCases.DTOs.Users;

namespace InternetShop.UseCases.DTOs.Orders;

public class OrderDTO
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public UserDTO UserDTO { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<Guid> ProductDTOs { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public UserStatuses StatusDTO { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата доставки
    /// </summary>
    public DateTime DeliveredDate { get; set; }
    public static OrderDTO Create(UserDTO userDTO, List<Guid> productDTOs, UserStatuses statusDTO, DateTime createdAt, DateTime deliveredDate)
    {
        return new OrderDTO()
        {
            Id = Guid.NewGuid(),
            UserDTO = userDTO,
            ProductDTOs = productDTOs,
            StatusDTO = statusDTO,
            CreatedAt = createdAt,
            DeliveredDate = deliveredDate
        };

    }
}
