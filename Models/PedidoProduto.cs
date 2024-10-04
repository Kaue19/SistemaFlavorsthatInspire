using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
    [Table("PedidoProduto")]
    public class PedidoProduto
    {
        [Column("PedidoProdutoId")]
        [Display(Name = "Código do Pedido")]
        public int PedidoProdutoId { get; set; }

        [ForeignKey("PedidoId")]
        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

    }
}