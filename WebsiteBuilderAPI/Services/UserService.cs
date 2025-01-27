//using MediaBrowser.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using WebsiteBuilderAPI.Data.WebsiteBuilderAPI.Data;
using WebsiteBuilderAPI.DTOs;
using WebsiteBuilderAPI.Services;
using ServiceResult = WebsiteBuilderAPI.DTOs.ServiceResult<WebsiteBuilderAPI.DTOs.UserDto>;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResult> RegisterUserAsync(UserDto userDto)
    {
        // Example implementation
        if (string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
        {
            return new WebsiteBuilderAPI.DTOs.ServiceResult<UserDto>
            {
                Success = false,
                Message = "Email and Password are required."
            };
        }

        // Simulate user registration logic here
        return new WebsiteBuilderAPI.DTOs.ServiceResult<UserDto>
        {
            Success = true,
            Message = "User registered successfully."
        };
    }

    public async Task<ServiceResult> AuthenticateUserAsync(LoginDto loginDto)
    { // Fetch the user from the database
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        // Check if the user exists
        if (user == null)
        {
            return new ServiceResult<UserDto>
            {
                Success = false,
                Message = "User not found."
            };
        }

        // Verify the password
        if (user.PasswordHash != loginDto.Password) // Use a secure hashing mechanism in real apps
        {
            return new ServiceResult<UserDto>
            {
                Success = false,
                Message = "Invalid password."
            };
        }

        // Return the user details
        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email
        };

        return new ServiceResult<UserDto>
        {
            Success = true,
            Data = userDto
        };
        // Implement authentication logic here
        throw new NotImplementedException();
    }
}

//public class UserService : IUserService
//{
//    private readonly AppDbContext _dbContext;

//    public UserService(AppDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    public async Task<ServiceResult<UserDto>> AuthenticateUserAsync(LoginDto loginDto)
//    {
//        // Fetch the user from the database
//        var user = await _dbContext.Users
//            .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

//        // Check if the user exists
//        if (user == null)
//        {
//            return new ServiceResult<UserDto>
//            {
//                Success = false,
//                Message = "User not found."
//            };
//        }

//        // Verify the password
//        if (user.Password != loginDto.Password) // Use a secure hashing mechanism in real apps
//        {
//            return new ServiceResult<UserDto>
//            {
//                Success = false,
//                Message = "Invalid password."
//            };
//        }

//        // Return the user details
//        var userDto = new UserDto
//        {
//            Id = user.Id,
//            Username = user.Username,
//            Email = user.Email
//        };

//        return new ServiceResult<UserDto>
//        {
//            Success = true,
//            Data = userDto
//        };
//    }
//}


