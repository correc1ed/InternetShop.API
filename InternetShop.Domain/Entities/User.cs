﻿using System.ComponentModel.DataAnnotations;

namespace InternetShop.Domain.Entities;

public class User
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Признак того, является-ли пользователь администратором.
    /// </summary>
    public bool IsAdministrator { get; set; }

    public User() { }

    public User(string name, string email, string password, bool isAdministrator)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        IsAdministrator = isAdministrator;
    }
}
