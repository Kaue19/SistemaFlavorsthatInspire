using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaFlavorsThatInspire.Migrations
{
    /// <inheritdoc />
    public partial class FotoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProdutoFoto",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoFoto",
                table: "Produto");
        }
    }
}
