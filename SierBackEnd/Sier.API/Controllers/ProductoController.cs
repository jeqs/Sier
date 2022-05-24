using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sier.Application.Common.Responses;
using Sier.Application.Producto.Commands;
using Sier.Application.Producto.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ProductoResponse> Get(int id)
        {
            return await _mediator.Send(new GetProductoQuery() { ProductoId = id });
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ProductoResponse>> GetAll()
        {
            return await _mediator.Send(new GetAllProductoQuery());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoResponse>> Post([FromBody] CreateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductoResponse>> Put([FromBody] UpdateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
