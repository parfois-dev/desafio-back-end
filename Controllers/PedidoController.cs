using DesafioApi.Dtos;
using DesafioApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoContext _context;

        public PedidoController(PedidoContext context)
        {
            _context = context;
        }

        [HttpGet("{numero}")]
        public ActionResult<PedidoDto> Get(string numero)
        {
            var pedido = _context.Get(numero);
            if (pedido == null)
                return NotFound();

            return Ok(ToDto(pedido));
        }

        [HttpPost]
        public ActionResult<PedidoDto> Post([FromBody] PedidoDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var pedido = FromDto(dto);
            _context.Add(pedido);
            return CreatedAtAction(nameof(Get), new { numero = pedido.Numero }, dto);
        }

        [HttpPut("{numero}")]
        public IActionResult Put(string numero, [FromBody] PedidoDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var pedido = _context.Get(numero);
            if (pedido == null)
                return NotFound();

            pedido.Itens = dto.Itens.Select(i => new PedidoItem
            {
                Descricao = i.Descricao,
                PrecoUnitario = i.PrecoUnitario,
                Qtd = i.Qtd
            }).ToList();
            _context.Update(pedido);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public IActionResult Delete(string numero)
        {
            var pedido = _context.Get(numero);
            if (pedido == null)
                return NotFound();

            _context.Delete(numero);
            return NoContent();
        }

        private static PedidoDto ToDto(Pedido pedido) => new PedidoDto
        {
            Pedido = pedido.Numero,
            Itens = pedido.Itens.Select(i => new PedidoItemDto
            {
                Descricao = i.Descricao,
                PrecoUnitario = i.PrecoUnitario,
                Qtd = i.Qtd
            }).ToList()
        };

        private static Pedido FromDto(PedidoDto dto) => new Pedido
        {
            Numero = dto.Pedido,
            Itens = dto.Itens.Select(i => new PedidoItem
            {
                Descricao = i.Descricao,
                PrecoUnitario = i.PrecoUnitario,
                Qtd = i.Qtd
            }).ToList()
        };
    }
}
