using MediatR;
using Microsoft.AspNetCore.Mvc;
using RotaDeViagem.Domain.Commands.Request;

namespace RotaDeViagem.API.Controllers
{
    [ApiController]
    [Route("rotas")]
    public class RotaViagemController : ControllerBase
    {
        private readonly ILogger<RotaViagemController> _logger;
        private readonly IMediator _mediator;

        public RotaViagemController(ILogger<RotaViagemController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddNewRotaRequest rota)
        {
            var result = await _mediator.Send(rota);
            return StatusCode(201, result);

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdRotaRequest rota)
        {
            var result = await _mediator.Send(rota);
            return StatusCode(200, result);

        }
        //[HttpGet("{uniqueId}")]
        //public async Task<ActionResult> GetByUniqueId(Guid uniqueId)
        //{
        //    var result = await _mediator.Send(new CorretorByUniqueId(uniqueId));
        //    return StatusCode(200, result);

        //}

        [HttpGet("maisbaratas")]
        public async Task<ActionResult> GetBy(string origem, string destino)
        {
            var result = await _mediator.Send(new FindRotaRequest() 
            { 
                Origem = origem,
                Destino = destino
            });
            return StatusCode(200, result);

        }

        [HttpDelete("{uniqueId}")]
        public async Task<ActionResult> DeleteByUniqueId(Guid uniqueId)
        {
            var result = await _mediator.Send(new DelRotaRequest(uniqueId));
            return StatusCode(200, result);

        }
    }
}
