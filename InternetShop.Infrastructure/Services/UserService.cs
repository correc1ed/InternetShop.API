﻿using AutoMapper;
using InternetShop.Domain.Entities;
using InternetShop.Domain.Interfaces.Repository;
using InternetShop.UseCases.Commands.User.PostUserLogin;
using InternetShop.UseCases.Commands.User.PostUserRegistration;
using InternetShop.UseCases.Commands.User.PutUserProfile;
using InternetShop.UseCases.Commands.User.PutUserProfileForAdmin;
using InternetShop.UseCases.DTOs.Users;
using InternetShop.UseCases.Interfaces.Users;

namespace InternetShop.Infrastructure.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(
        IUserRepository userRepository,
		IMapper mapper
    )
    {
        _userRepository = userRepository;
		_mapper = mapper;
    }

    public async Task RegisterAsync(PostUserRegistrationCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Password is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Password is null)   
            throw new ArgumentNullException(nameof(request));

        var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var user = new User(request.Name, request.Email, hashedPassword, false);

        await _userRepository.AddAsync(user);
    }

    public async Task<UserDTO> AuthorizeAsync(PostUserLoginCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var users = await _userRepository.GetAllAsync();
        var user = users.FirstOrDefault(x => x.Email == request.Email);


        if (user == null)
        {
            throw new Exception("Пользователя с данным логином не существует или вы не правильно его указали");
        }

        if (PasswordEncryptionService.VerifyPassword(request.Password, user.Password))
        {
            return _mapper.Map<UserDTO>(user);
        }
        else
        {
            throw new Exception("Пароль введён неверно");
        }
    }

    public async Task UpdateUserByIdAsync(Guid userId, PutUserProfileCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("Пользователя с данным идентификатором не существует или вы не правильно его указали");
        }

        var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var resultUser = new User()
        {
            Id = user.Id,
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword
        };

        await _userRepository.UpdateAsync(resultUser);
    }

    public async Task UpdateUserForAdminByIdAsync(Guid userId, PutUserProfileForAdminCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            throw new Exception("Пользователя с данным идентификатором не существует или вы не правильно его указали");
		} 

		if (string.IsNullOrWhiteSpace(request.Name))
		{
			throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(request.Name));
		}

		if (string.IsNullOrWhiteSpace(request.Email))
		{
			throw new ArgumentException("Почта пользователя не может быть пустой.", nameof(request.Email));
		}

		if (string.IsNullOrWhiteSpace(request.Password))
		{
			throw new ArgumentException("Пароль не может быть пустым.", nameof(request.Password));
		}
		if (request.Password.Length < 8)
		{
			throw new ArgumentException("Пароль должен содержать минимум 8 символов.", nameof(request.Password));
		}

		var hashedPassword = PasswordEncryptionService.HashPassword(request.Password);

        var resultUser = new User()
        {
            Id = user.Id,
            Name = request.Name,
            Email = request.Email,
            Password = hashedPassword,
            IsAdministrator = request.IsAdministrator
        };

        await _userRepository.UpdateAsync(resultUser);
    }
}
