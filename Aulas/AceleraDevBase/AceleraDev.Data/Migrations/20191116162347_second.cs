using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "pedido",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClienteId",
                table: "pedido",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
