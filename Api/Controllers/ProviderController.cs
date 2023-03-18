using Application.Dtos.Provider.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Api.Controllers
{
    [Authorize]
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetByIdProvider(int id)
        {
            var provider = await _providerApplication.GetByIdProvider(id);
            return Ok(provider);
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterProvider(ProviderRequestDto requestDto)
        {
            var provider = await _providerApplication.RegisterProvider(requestDto);
            return Ok(provider);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<ActionResult> EditProvider(int id, ProviderRequestDto requestDto)
        {
            var provider = await _providerApplication.EditProvider(id, requestDto);
            return Ok(provider);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> RemoveProvider(int id)
        {
            var provider = await _providerApplication.RemoveProvider(id);
            return Ok(provider);
        }
    }
}
