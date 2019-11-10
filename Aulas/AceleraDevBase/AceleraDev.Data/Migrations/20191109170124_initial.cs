using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AceleraDev.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18, 4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    Rua = table.Column<string>(maxLength: 255, nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    Complemento = table.Column<string>(maxLength: 255, nullable: true),
                    Cidade = table.Column<string>(maxLength: 255, nullable: true),
                    Estado = table.Column<string>(maxLength: 255, nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_endereco_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    DDI = table.Column<string>(maxLength: 3, nullable: true),
                    DDD = table.Column<string>(maxLength: 3, nullable: false),
                    Numero = table.Column<string>(maxLength: 9, nullable: false),
                    Contato = table.Column<string>(maxLength: 255, nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_telefone_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => new { x.PedidoId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_item_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_endereco_ClienteId",
                table: "endereco",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_ProdutoId",
                table: "pedido_item",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_telefone_ClienteId",
                table: "telefone",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "pedido_item");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
