using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3_Proyecto_Software.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comanda_FormaEntrega_FormaEntregaId",
                        column: x => x.FormaEntregaId,
                        principalTable: "FormaEntrega",
                        principalColumn: "FormaEntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                    table.ForeignKey(
                        name: "FK_Mercaderia_TipoMercaderia_TipoMercaderiaId",
                        column: x => x.TipoMercaderiaId,
                        principalTable: "TipoMercaderia",
                        principalColumn: "TipoMercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Comanda_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comanda",
                        principalColumn: "ComandaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaMercaderia_Mercaderia_MercaderiaId",
                        column: x => x.MercaderiaId,
                        principalTable: "Mercaderia",
                        principalColumn: "MercaderiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza artesanal" },
                    { 10, "Postre" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "https://localhost:5001/Home/Imagenes/?id=1", "(ingredientes)", "Empanadas de carne", 100, "(preparacion)", 1 },
                    { 18, "https://localhost:5001/Home/Imagenes/?id=18", "(ingredientes)", "Cerveza negra", 200, "(preparacion)", 9 },
                    { 17, "https://localhost:5001/Home/Imagenes/?id=17", "(ingredientes)", "Cerveza común", 200, "(preparacion)", 9 },
                    { 16, "https://localhost:5001/Home/Imagenes/?id=16", "(ingredientes)", "Gaseosa", 100, "(preparacion)", 8 },
                    { 15, "https://localhost:5001/Home/Imagenes/?id=15", "(ingredientes)", "Vino", 200, "(preparacion)", 8 },
                    { 14, "https://localhost:5001/Home/Imagenes/?id=14", "(ingredientes)", "Ensalada de frutas", 100, "(preparacion)", 7 },
                    { 13, "https://localhost:5001/Home/Imagenes/?id=13", "(ingredientes)", "Ensalada común", 100, "(preparacion)", 7 },
                    { 12, "https://localhost:5001/Home/Imagenes/?id=12", "(ingredientes)", "Sandwich de verdura", 100, "(preparacion)", 6 },
                    { 11, "https://localhost:5001/Home/Imagenes/?id=11", "(ingredientes)", "Sandwich de jamón", 100, "(preparacion)", 6 },
                    { 10, "https://localhost:5001/Home/Imagenes/?id=10", "(ingredientes)", "Pizza de verduras", 200, "(preparacion)", 5 },
                    { 9, "https://localhost:5001/Home/Imagenes/?id=9", "(ingredientes)", "Pizza de muzzarella", 200, "(preparacion)", 5 },
                    { 8, "https://localhost:5001/Home/Imagenes/?id=8", "(ingredientes)", "Asado", 300, "(preparacion)", 4 },
                    { 7, "https://localhost:5001/Home/Imagenes/?id=7", "(ingredientes)", "Choripán", 200, "(preparacion)", 4 },
                    { 6, "https://localhost:5001/Home/Imagenes/?id=6", "(ingredientes)", "Ñoquis", 200, "(preparacion)", 3 },
                    { 5, "https://localhost:5001/Home/Imagenes/?id=5", "(ingredientes)", "Fideos", 200, "(preparacion)", 3 },
                    { 4, "https://localhost:5001/Home/Imagenes/?id=4", "(ingredientes)", "Huevo frito", 100, "(preparacion)", 2 },
                    { 3, "https://localhost:5001/Home/Imagenes/?id=3", "(ingredientes)", "Milanesa", 100, "(preparacion)", 2 },
                    { 2, "https://localhost:5001/Home/Imagenes/?id=2", "(ingredientes)", "Empanadas de verdura", 100, "(preparacion)", 1 },
                    { 19, "https://localhost:5001/Home/Imagenes/?id=19", "(ingredientes)", "Flan", 200, "(preparacion)", 10 },
                    { 20, "https://localhost:5001/Home/Imagenes/?id=20", "(ingredientes)", "Helado", 200, "(preparacion)", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_FormaEntregaId",
                table: "Comanda",
                column: "FormaEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_ComandaId",
                table: "ComandaMercaderia",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaMercaderia_MercaderiaId",
                table: "ComandaMercaderia",
                column: "MercaderiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mercaderia_TipoMercaderiaId",
                table: "Mercaderia",
                column: "TipoMercaderiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
