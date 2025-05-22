using System.ComponentModel.DataAnnotations;

namespace DesafioApi.Dtos
{
    public class PedidoDto
    {
        [Required]
        public string Pedido { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<PedidoItemDto> Itens { get; set; } = new();
    }
}
