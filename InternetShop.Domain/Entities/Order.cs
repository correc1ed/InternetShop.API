using InternetShop.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InternetShop.Domain.Entities;

public class Order
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Товары
    /// </summary>
    public List<Guid> Products { get; set; }

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

    [JsonConstructor]
    public Order() { }

    public static Order Create(User user, List<Guid> products, Status status, DateTime createdAt, DateTime deliveredDate)
    {
        return new Order()
        {
            Id = Guid.NewGuid(),
            User = user,
            Products = products,
            Status = status,
            CreatedAt = createdAt,
            DeliveredDate = deliveredDate
        };

    }
}
