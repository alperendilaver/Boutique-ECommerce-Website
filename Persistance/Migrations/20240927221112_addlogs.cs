using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cee714d-cf98-4380-a40e-837b5d3bd8b9");

            migrationBuilder.CreateTable(
                name: "ProductRouteLog",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDolap = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRouteLog", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_ProductRouteLog_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e8eef75-cb22-4b2a-a605-ea97ff13dd62", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa510d70-c31f-4fcd-9940-947c32249bd8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b326cad7-fadc-465f-84db-61a7472a3d29", "62dce887-af3a-48ba-af73-df1f1f203b02" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductRouteLog_ProductId",
                table: "ProductRouteLog",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRouteLog");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e8eef75-cb22-4b2a-a605-ea97ff13dd62");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3cee714d-cf98-4380-a40e-837b5d3bd8b9", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa510d70-c31f-4fcd-9940-947c32249bd8",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "23b60614-b5be-4be6-832e-9e0565726c2a", "465f549a-bb27-42aa-8dad-9be91a3d36fb" });
        }
    }
}
