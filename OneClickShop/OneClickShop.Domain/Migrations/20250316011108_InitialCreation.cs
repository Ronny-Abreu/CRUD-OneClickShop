using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneClickShop.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Descripcion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "Teléfono inteligente de gama alta lanzado por Apple en octubre de 2020. Destaca por su pantalla Super Retina XDR de 6.7 pulgadas y el chip A14 Bionic", "Iphone 12 Pro Max", 32000m, 40 },
                    { 2, " portátil ligero y eficiente con pantalla Retina, teclado Magic Keyboard y procesadores Intel de 10ª generación, ideal para productividad y uso diario.", "MacBook Air 2020", 40000m, 12 },
                    { 3, " potente estación de trabajo todo en uno diseñada para profesionales, con hardware de alto rendimiento y una pantalla Retina 5K.", "iMac Pro 2019", 300000m, 7 },
                    { 4, "Laptop premium con pantalla Retina, procesador M1 Pro/Max y diseño compacto para creativos y profesionales.", "MacBook Pro 16", 55000m, 21 },
                    { 5, "Smartphone avanzado con pantalla Super Retina XDR, cámara triple y rendimiento optimizado con el chip A15 Bionic.", "iPhone 13 Pro", 30000m, 200 },
                    { 6, "Tablet versátil con pantalla Liquid Retina, chip M1 y compatibilidad con Apple Pencil y Magic Keyboard.", "iPad Air 2022", 80000m, 12 },
                    { 7, "Reloj inteligente con monitorización avanzada de salud, pantalla Always-On y resistencia al agua.", "Apple Watch Series 8", 50000m, 55 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
