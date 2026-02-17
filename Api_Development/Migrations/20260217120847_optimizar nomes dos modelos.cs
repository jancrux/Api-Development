using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api_Development.Migrations
{
    /// <inheritdoc />
    public partial class optimizarnomesdosmodelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dificuldades",
                columns: table => new
                {
                    DificuldadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dificuldades", x => x.DificuldadeId);
                });

            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    RegiaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ImagemRegiaoUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.RegiaoId);
                });

            migrationBuilder.CreateTable(
                name: "Caminhadas",
                columns: table => new
                {
                    CaminhadaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    DistanciaKm = table.Column<double>(type: "double precision", nullable: false),
                    CaminhadaImagemUrl = table.Column<string>(type: "text", nullable: true),
                    DificuldadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegiaoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caminhadas", x => x.CaminhadaId);
                    table.ForeignKey(
                        name: "FK_Caminhadas_Dificuldades_DificuldadeId",
                        column: x => x.DificuldadeId,
                        principalTable: "Dificuldades",
                        principalColumn: "DificuldadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Caminhadas_Regioes_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regioes",
                        principalColumn: "RegiaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dificuldades",
                columns: new[] { "DificuldadeId", "Nome" },
                values: new object[,]
                {
                    { new Guid("d1bfbf8e-9c3a-4c5e-9a1b-1a2b3c4d5e6f"), "Fácil" },
                    { new Guid("e2c1a9f7-8b4d-4f6e-9b2c-2b3c4d5e6f70"), "Médio" },
                    { new Guid("f3d2b8c6-7a5e-4a7f-9c3d-3c4d5e6f7a8b"), "Difícil" }
                });

            migrationBuilder.InsertData(
                table: "Regioes",
                columns: new[] { "RegiaoId", "Codigo", "ImagemRegiaoUrl", "Nome" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a8b-9c0d-1e2f3a4b5c6d"), "Nor", "https://example.com/images/north.jpg", "Norte" },
                    { new Guid("b2c3d4e5-f6a7-4b9c-0d1e-2f3a4b5c6d7e"), "Sul", "https://example.com/images/south.jpg", "Sul" },
                    { new Guid("c3d4e5f6-a7b8-4c0d-1e2f-3a4b5c6d7e8f"), "Oes", "https://example.com/images/East.jpg", "Oeste" },
                    { new Guid("d4e5f6a7-b8c9-4d0e-1f2a-3b4c5d6e7f8a"), "Est", "https://example.com/images/West.jpg", "Este" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caminhadas_DificuldadeId",
                table: "Caminhadas",
                column: "DificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Caminhadas_RegiaoId",
                table: "Caminhadas",
                column: "RegiaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caminhadas");

            migrationBuilder.DropTable(
                name: "Dificuldades");

            migrationBuilder.DropTable(
                name: "Regioes");
        }
    }
}
