using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sier.Application.Common.Responses;
using Sier.Application.DetalleProducto.Commands;
using Sier.Application.DetalleProducto.Queries;
using System.Threading.Tasks;

namespace Sier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleProductoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DetalleProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DetalleProductoResponse> Get(int id)
        {
            return await _mediator.Send(new GetDetalleProductoQuery() { IdDetalleProducto = id });
        }

        [HttpGet]
        [Route("GetPorProductoId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DetalleProductoResponse> GetPorProductoId(int id)
        {
            return await _mediator.Send(new GetDetalleProductoPorProductoQuery() { IdProducto = id });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DetalleProductoResponse>> Post([FromBody] CreateDetalleProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DetalleProductoResponse>> Put([FromBody] UpdateDetalleProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
