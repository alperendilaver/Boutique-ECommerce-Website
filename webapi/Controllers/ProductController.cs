using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Queries.ProductQuery;
using Application.Features.Commands;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Handlers.ProductHandlers;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _mediator.Send(new ProductQuery());
            return Ok(values);
        }
        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory(int categoryId)
        {
            var values = await _mediator.Send(new ProductByCategoryQuery(categoryId));
            return Ok(values);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var values = await _mediator.Send(new ProductByNameQuery(name));
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _mediator.Send(new ProductQueryById(id));
            return Ok(value);
        }
        [HttpGet("favorites/{userId}")]
        public async Task<IActionResult> GetUserFavorites(string userId)
        {
            var values = await _mediator.Send(new GetUserFavorites(userId));
            return Ok(values);
        }
       
        [HttpPost("addfavorite")]
        public async Task<IActionResult> AddFavoriteProduct(AddFavoriteProductCommand command)
        {
            await _mediator.Send(command);
            return Ok("Favorilere eklendi");
        }
      
        [HttpDelete("removefavorite")]
        public async Task<IActionResult> RemoveFavoriteProduct(RemoveFavoriteProduct command)
        {
            await _mediator.Send(command);
            return Ok("Favorilerden kaldırıldı");
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomProducts()
        {
            var values = await _mediator.Send(new GetRandomSixProductsQuery());
            return Ok(values);
        }
        [HttpPost("Log")]
        public async Task<IActionResult> LogRoute(LogProductRouteCommand command){
            await _mediator.Send(command);
            return Ok("Loglandı");
        }
        
    }
}