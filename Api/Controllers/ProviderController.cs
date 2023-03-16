using Application.Interfaces;
using Infrastructure.Commons.Bases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderApplication _providerApplication;

        public ProviderController(IProviderApplication providerApplication)
        {
            _providerApplication = providerApplication;
        }

        [HttpPost]
        public async Task<ActionResult> ListProvider([FromBody] BaseFiltersRequest filter)
        {
            var provider = await _providerApplication.ListProvider(filter); 
            return Ok(provider);
        }

        [HttpGet("{providerId:int}")]
        public async Task<ActionResult> GetByIdProvider(int providerId)
        {
            var provider = await _providerApplication.GetByIdProvider(providerId);
            return Ok(provider);
        }
    }
}
