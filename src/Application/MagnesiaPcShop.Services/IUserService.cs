using MagnesiaPcShop.DataTransferObjects.Requests.User;

namespace MagnesiaBilgisayar.Application.Services
{
    public interface IUserService
    {
        Task CreateNewUser(CreateNewUserRequest request);
    }
}