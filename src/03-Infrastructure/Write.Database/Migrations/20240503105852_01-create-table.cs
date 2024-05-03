using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RotaDeViagem.Write.Database.Migrations
{
    /// <inheritdoc />
    public partial class _01createtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Rota",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origem = table.Column<string>(type: "varchar(3)", nullable: false),
                    Destino = table.Column<string>(type: "varchar(3)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    UniqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rota",
                schema: "dbo");
        }
    }
}
