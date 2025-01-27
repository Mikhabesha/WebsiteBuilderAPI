using WebsiteBuilderAPI.DTOs;

namespace WebsiteBuilderAPI.Services
{
    public interface IWebsiteService
    {
        Task<ServiceResult<UserDto>> CreateWebsiteAsync(WebsiteDto websiteDto);
        Task<WebsiteDto> GetWebsiteByIdAsync(int id);
    }

}
