﻿using MagnesiaPcShop.DataTransferObjects.Requests.User;
using MagnesiaPcShop.DataTransferObjects.Responses.User;
using MagnesiaPcShop.Entities;

namespace MagnesiaBilgisayar.Application.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateNewUserRequest request);
        Task<int> GetUserIdByEmailAsync(string userEmail);
        Task<UserValidateResponse> ValidateUserAsync(ValidateUserLoginRequest request);
    }
}