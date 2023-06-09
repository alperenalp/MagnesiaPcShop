using AutoMapper;
using MagnesiaBilgisayar.Application.Services;
using MagnesiaPcShop.DataTransferObjects.Requests.User;
using MagnesiaPcShop.DataTransferObjects.Responses.User;
using MagnesiaPcShop.Infrastructure.Repositories;
using MagnesiaPcShop.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(CreateNewUserRequest request)
        {
            var user = request.ConvertToUser(_mapper);
            user.Role = "Client";
            await _userRepository.CreateAsync(user);
        }

        public async Task<UserValidateResponse> ValidateUserAsync(ValidateUserLoginRequest request)
        {
            var users = await _userRepository.GetAllAsync();
            var response = users.SingleOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            return response.ConvertToDto<UserValidateResponse>(_mapper);
        }
    }
}
