using Application.Features.Commands;
using Application.Features.Commands.CategoryCommands;
using Application.Features.Queries.IdentityQuery;
using Application.Features.Queries.ProductQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
     public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncellendi");
        }
        [HttpDelete("RemoveProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommand { Id = id });
            return Ok("Silindi");
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarılı");
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncellendi");
        }
        [HttpDelete("RemoveCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand { CategoryId = id });
            return Ok("Silindi");
        }

        [HttpGet("GetProductsCount")]
        public async Task<IActionResult> GetProductsCount(){
            var cnt =await _mediator.Send(new GetTotalProductsQuery());
            return Ok(cnt);
        }
        [HttpGet("GetLogs/{prodId}")] 
        public async Task<IActionResult> GetProductLogs(int prodId){
            var values = await _mediator.Send(new GetProductLogsQueryById(prodId));
            return Ok(values);
        }
        [HttpGet("LogCount")]
        public async Task<IActionResult> GetLogCount(){
            var value = await _mediator.Send(new GetLogsCountQuery());
            return Ok(value);
        }
        [HttpGet("GetUserCount")]
        public async Task<IActionResult> GetUserCount()
        {
            var value = await _mediator.Send(new GetUserCountQuery());
            return Ok(value);
        }
    }
}
