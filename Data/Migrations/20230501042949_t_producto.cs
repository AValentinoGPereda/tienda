using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace myapp.Data.Migrations
{
    /// <inheritdoc />
    public partial class t_producto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prod = table.Column<string>(type: "text", nullable: true),
                    prec = table.Column<decimal>(type: "numeric", nullable: false),
                    tipo = table.Column<string>(type: "text", nullable: true),
                    desc = table.Column<decimal>(type: "numeric", nullable: false),
                    descr = table.Column<string>(type: "text", nullable: true),
                    categ = table.Column<string>(type: "text", nullable: true),
                    Prec_final = table.Column<decimal>(type: "numeric", nullable: false),
                    imgProd = table.Column<string>(type: "text", nullable: true),
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
        }
    }
}
