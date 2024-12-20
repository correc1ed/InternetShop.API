﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InternetShop.Domain.Entities;

public class Product
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Название товара
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Описание товара
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Цена товара
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Количество на складе
    /// </summary>
    public int CountInStorage { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public string? Category { get; set; }

    [JsonConstructor]
    public Product() { }
    public static Product Add(string name, string description, decimal price, int countInStorage, string category)
    {
        return new Product()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            CountInStorage = countInStorage,
            Category = category
        };
    }
}
