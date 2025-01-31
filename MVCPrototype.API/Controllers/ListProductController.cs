using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MVCPrototype.Application.Services;
using MVCPrototype.Application.Services.agrofitApi;
using MVCPrototype.Domain.Entities;

namespace MVCPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListProductController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        private readonly AgrofitApi _apiService;
        private readonly TokenService _tokenService;


        public ListProductController(IConfiguration configuration, AgrofitApi apiService, TokenService tokenService)
        {
            _configuration = configuration;
            _apiService = apiService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            string accessToken = await _tokenService.GetAccessTokenAsync();
            List<ProdutosFormuladosResponse> response = await _apiService.GetAgroDataAsync(accessToken);

            return StatusCode(200, response);
        }
    }
}
