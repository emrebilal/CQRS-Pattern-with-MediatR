using DAL.Commands.Request;
using DAL.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allProducts = await _mediator.Send(new GetAllProductRequest());

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var product = await _mediator.Send(new GetByIdProductRequest
            {
                Id = Guid.Parse(id)
            });

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest requestModel)
        {
            var response = await _mediator.Send(new CreateProductRequest 
            {
                Name = requestModel.Name,
                Price = requestModel.Price,
                Quantity = requestModel.Quantity
            });

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _mediator.Send(new DeleteProductRequest
            {
                Id = Guid.Parse(id)
            });

            return Ok(response);
        }
    }
}
