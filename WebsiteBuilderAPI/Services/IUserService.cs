using Microsoft.Exchange.WebServices.Data;
using WebsiteBuilderAPI.DTOs;

namespace WebsiteBuilderAPI.Services
{
    public interface IUserService
    {
        Task<DTOs.ServiceResult<UserDto>> RegisterUserAsync(UserDto userDto);
        Task<DTOs.ServiceResult<UserDto>> AuthenticateUserAsync(LoginDto loginDto);
        //Task<ServiceResult<UserDto>> AuthenticateUserAsync(LoginDto loginDto);
    }


}
