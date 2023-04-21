using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "registro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registro",
                table: "registro",
                column: "id_usu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_registro",
                table: "registro");

            migrationBuilder.RenameTable(
                name: "registro",
                newName: "usuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "id_usu");
        }
    }
}
