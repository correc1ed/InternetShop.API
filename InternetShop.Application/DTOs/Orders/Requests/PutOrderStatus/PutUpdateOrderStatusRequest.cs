using InternetShop.Domain.Entities.Enums;

namespace InternetShop.UseCases.DTOs.Orders.Requests.PutOrderStatus;
public class PutUpdateOrderStatusRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PutUpdateOrderStatusRequest(PutUpdateOrderStatusRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        Status = request.Status;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public PutUpdateOrderStatusRequest()
    {
    }

    /// <summary>
    /// Статус
    /// </summary>
    public Status Status { get; set; }
}
