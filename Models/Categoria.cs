using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("CategoriaId")]
        [Display(Name = "Código da Categoria")]
        public int CategoriaId { get; set; }

        [Column("CategoriaNome")]
        [Display(Name = "Nome da Categoria")]
        public string CategoriaNome { get; set; } = string.Empty;
    }
}
