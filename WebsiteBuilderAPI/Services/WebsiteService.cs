using WebsiteBuilderAPI.DTOs;

namespace WebsiteBuilderAPI.Services
{
    public class WebsiteService : IWebsiteService
    {
        public Task<ServiceResult<UserDto>> CreateWebsiteAsync(WebsiteDto websiteDto)
        {
            // Implement website creation logic
            throw new NotImplementedException();
        }

        public Task<WebsiteDto> GetWebsiteByIdAsync(int id)
        {
            // Implement website retrieval logic
            throw new NotImplementedException();
        }
    }

}
