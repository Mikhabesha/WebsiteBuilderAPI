using Microsoft.AspNetCore.Mvc;
using WebsiteBuilderAPI.DTOs;
using WebsiteBuilderAPI.Services;

namespace WebsiteBuilderAPI.Controllers
{
    
        [ApiController]
        [Route("api/websites")]
        public class WebsitesController : ControllerBase
        {
            private readonly IWebsiteService _websiteService;

            public WebsitesController(IWebsiteService websiteService)
            {
                _websiteService = websiteService;
            }

            [HttpPost]
            public async Task<IActionResult> CreateWebsite([FromBody] WebsiteDto websiteDto)
            {
                var result = await _websiteService.CreateWebsiteAsync(websiteDto);
                if (!result.Success)
                    return BadRequest(result.Message);

                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetWebsite(int id)
            {
                var result = await _websiteService.GetWebsiteByIdAsync(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
        }

    }

