using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using SistemaFlavorsThatInspire.Models;

namespace SistemaFlavorsThatInspire.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProduto> PedidoProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<StatusDaEntrega> StatusDaEntrega { get; set; }
       
    }
}

