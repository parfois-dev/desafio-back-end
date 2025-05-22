using System.ComponentModel.DataAnnotations;

namespace DesafioApi.Dtos
{
    public class PedidoItemDto
    {
        [Required]
        public string Descricao { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue)]
        public decimal PrecoUnitario { get; set; }

        [Range(1, int.MaxValue)]
        public int Qtd { get; set; }
    }
}
