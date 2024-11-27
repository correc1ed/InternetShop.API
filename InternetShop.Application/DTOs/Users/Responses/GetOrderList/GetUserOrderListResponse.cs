﻿using InternetShop.Domain.Entities;

namespace InternetShop.UseCases.DTOs.Users.Responses.GetOrderList;
public class GetUserOrderListResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public GetUserOrderListResponse()
    { }

    /// <summary>
    /// Список заказов
    /// </summary>
    public List<Order> Orders { get; set; }
}
