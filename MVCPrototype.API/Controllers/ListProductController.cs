using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCPrototype.Application.Services;
using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListProductController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        private readonly ApiService _apiService;
        private readonly TokenService _tokenService;


        public ListProductController(IConfiguration configuration, ApiService apiService, TokenService tokenService)
        {
            _configuration = configuration;
            _apiService = apiService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            string accessToken = await _tokenService.GetAccessTokenAsync();
            string response = await _apiService.GetAgroDataAsync(accessToken);

            return StatusCode(200, response);
        }
    }
}
