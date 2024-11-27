using InternetShop.Domain.Entities;
using InternetShop.Domain.Entities.Enums;

namespace InternetShop.UseCases.DTOs.Orders.Responses.GetOrderInformationById;

public class GetOrderInfoByIdResponse
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Дата доставки
    /// </summary>
    public DateTime DeliveredDate { get; set; }
}
