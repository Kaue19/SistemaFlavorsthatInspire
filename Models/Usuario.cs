using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFlavorsThatInspire.Models
{
   [Table("Usuario")]
    public class Usuario
    {
        [Column("UsuarioId")]
        [Display(Name = "Código do Usuário")]
        public int UsuarioId { get; set; }

        [Column("NomeUsuario")]
        [Display(Name = "Nome do Usuario")]
        public string NomeUsuario { get; set; } = string.Empty;


        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Column("Endereco")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public int Telefone { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; } = string.Empty;

        [Column("ConfirmarSenha")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmarSenha { get; set; } = string.Empty;
    }
}
