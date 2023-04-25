using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace myapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initia_lMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_registro",
                table: "registro");

            migrationBuilder.RenameTable(
                name: "registro",
                newName: "usuario_");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario_",
                table: "usuario_",
                column: "id_usu");

            migrationBuilder.CreateTable(
                name: "t_producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_producto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario_",
                table: "usuario_");

            migrationBuilder.RenameTable(
                name: "usuario_",
                newName: "registro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registro",
                table: "registro",
                column: "id_usu");
        }
    }
}
