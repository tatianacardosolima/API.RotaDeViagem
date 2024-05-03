using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RotaDeViagem.Write.Database.Migrations
{
    /// <inheritdoc />
    public partial class _02insertrota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "Rota",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Rota",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Destino", "IsDeleted", "ModifiedAt", "ModifiedBy", "Origem", "UniqueId", "Valor" },
                values: new object[,]
                {
                    { 6, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8301), "1", "BRC", false, null, null, "GRU", new Guid("7c7bb765-2e9c-437c-a784-2f9c99d151e0"), 10m },
                    { 7, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8322), "1", "SCL", false, null, null, "BRC", new Guid("2d490c3f-2e33-4514-926f-fdb6057a838b"), 5m },
                    { 8, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8324), "1", "CDG", false, null, null, "GRU", new Guid("871ad9ec-e8cf-4335-9847-091ffc3be2d2"), 75m },
                    { 9, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8326), "1", "SCL", false, null, null, "GRU", new Guid("de7411f4-e2a5-4832-886f-22866f4698a2"), 20m },
                    { 10, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8328), "1", "ORL", false, null, null, "GRU", new Guid("7abc463d-b4ff-4eb1-a077-bae6da7d461a"), 56m },
                    { 11, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8329), "1", "CDG", false, null, null, "ORL", new Guid("fefa25b3-8784-4d5e-92a6-35a0550ed428"), 5m },
                    { 12, new DateTime(2024, 5, 3, 8, 56, 21, 204, DateTimeKind.Local).AddTicks(8331), "1", "ORL", false, null, null, "SCL", new Guid("77699955-4f0f-4d23-9f8b-248232b02a75"), 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Rota",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "dbo",
                table: "Rota",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
