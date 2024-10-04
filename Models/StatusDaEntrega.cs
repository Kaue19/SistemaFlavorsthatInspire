using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
    [Table("StatusDaEntrega")]
    public class StatusDaEntrega
    {
        [Column("StatusDaEntregaId")]
        [Display(Name = "Código do Status Da Entrega")]
        public int StatusDaEntregaId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("PedidoId")]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [Column("DataSaida")]
        [Display(Name = "Data da Saída")]
        public DateTime DataSaida { get; set; }

        [Column("DataEntrega")]
        [Display(Name = "Data da Entrega")]
        public DateTime DataEntrega { get; set; }
    }
}
