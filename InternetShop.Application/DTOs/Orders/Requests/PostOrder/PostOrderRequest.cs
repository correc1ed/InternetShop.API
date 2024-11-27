using InternetShop.Domain.Entities;
using InternetShop.Domain.Entities.Enums;

namespace InternetShop.UseCases.DTOs.Orders.Requests.PostOrder;
public class PostOrderRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostOrderRequest(PostOrderRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        User = request.User;
        Products = request.Products;
        Status = request.Status;
        CreatedAt = request.CreatedAt;
        DeliveredDate = request.DeliveredDate;
    }
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
