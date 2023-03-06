using Application.Dtos.Category.Request;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpPost()]
        public async Task<ActionResult> ListCategory([FromBody] BaseFiltersRequest filtes)
        {
            var response = await _categoryApplication.ListCategory(filtes);
            return Ok(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult> ListSelectCategory()
        {
            var response = await _categoryApplication.ListSelectCategory();
            return Ok(response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<ActionResult> CategoryById(int categoryId)
        {
            var response = await _categoryApplication.CategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
        {
            var response = await _categoryApplication.RegisterCategory(requestDto);
            return Ok(response);
        }

        [HttpPut("edit/{categoryId:int}")]
        public async Task<ActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDto requestDto)
        {
            var response = await _categoryApplication.EditCategory(categoryId, requestDto);
            return Ok(response);
        }
        
        [HttpDelete("remove/{categoryId:int}")]
        public async Task<ActionResult> RemoveCategory(int categoryId)
        {
            var response = await _categoryApplication.RemoveCategory(categoryId);
            return Ok(response);
        }
    }
}
