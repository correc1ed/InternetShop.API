using InternetShop.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.Domain.Entities;

public class Basket
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
    public List<Product> Products { get; set; }

    /// <summary>
    /// Полная цена
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }
}
