using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Column("PedidoId")]
        [Display(Name = "Código do Pedido")]
        public int PedidoId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [Column("PrecoPedido")]
        [Display(Name = "PrecoPedido")]
        public double PrecoPedido { get; set; }

    }
}
