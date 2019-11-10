using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class ajuste_itempedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorItem",
                table: "pedido_item",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorItem",
                table: "pedido_item");
        }
    }
}
