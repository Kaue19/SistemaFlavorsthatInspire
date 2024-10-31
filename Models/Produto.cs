using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("ProdutoId")]
        [Display(Name = "Código do Produto")]
        public int ProdutoId { get; set; }

        [Column("ProdutoNome")]
        [Display(Name = "Nome do Produto")]
        public string ProdutoNome { get; set; } = string.Empty;


        [Column("ProdutoDescricao")]
        [Display(Name = "Produto Descrição")]
        public string ProdutoDescricao { get; set; } = string.Empty;

        [Column("ProdutoFoto")]
        [Display(Name = "Produto Foto")]
        public string ProdutoFoto { get; set; } = string.Empty;



        [Column("ProdutoPreco")]
        [Display(Name = "Produto Preço")]
        public double ProdutoPreco { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        [Column("ProdutoDesconto")]
        [Display(Name = "Produto Desconto")]
        public double ProdutoDesconto { get; set; }
    }
}
