using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRouteLog_Products_ProductId",
                table: "ProductRouteLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRouteLog",
                table: "ProductRouteLog");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e8eef75-cb22-4b2a-a605-ea97ff13dd62");

            migrationBuilder.RenameTable(
                name: "ProductRouteLog",
                newName: "ProductRouteLogs");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRouteLog_ProductId",
                table: "ProductRouteLogs",
                newName: "IX_ProductRouteLogs_ProductId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ProductRouteLogs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRouteLogs",
                table: "ProductRouteLogs",
                column: "LogId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68a09be4-184b-4a73-8a3b-7e8907495d66", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa510d70-c31f-4fcd-9940-947c32249bd8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "SecurityStamp" },
                values: new object[] { "f22f48ec-7e1d-4b01-a855-d0f27199ef02", "ADM�N@GMAIL.COM", "e0031270-391a-4551-80b0-d443f30c2e28" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRouteLogs_Products_ProductId",
                table: "ProductRouteLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRouteLogs_Products_ProductId",
                table: "ProductRouteLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductRouteLogs",
                table: "ProductRouteLogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a09be4-184b-4a73-8a3b-7e8907495d66");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductRouteLogs");

            migrationBuilder.RenameTable(
                name: "ProductRouteLogs",
                newName: "ProductRouteLog");

            migrationBuilder.RenameIndex(
                name: "IX_ProductRouteLogs_ProductId",
                table: "ProductRouteLog",
                newName: "IX_ProductRouteLog_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductRouteLog",
                table: "ProductRouteLog",
                column: "LogId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e8eef75-cb22-4b2a-a605-ea97ff13dd62", null, "Member", "MEMBER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa510d70-c31f-4fcd-9940-947c32249bd8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "SecurityStamp" },
                values: new object[] { "b326cad7-fadc-465f-84db-61a7472a3d29", "ADMİN@GMAIL.COM", "62dce887-af3a-48ba-af73-df1f1f203b02" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRouteLog_Products_ProductId",
                table: "ProductRouteLog",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
