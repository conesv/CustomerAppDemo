using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderproduct_Orders_orderId",
                table: "Orderproduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderproduct_product_productId",
                table: "Orderproduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderproduct",
                table: "Orderproduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "Orderproduct",
                newName: "OrderProduct");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Orderproduct_productId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_productId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateShipped",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "products",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "orderId", "productId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_orderId",
                table: "OrderProduct",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_products_productId",
                table: "OrderProduct",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_orderId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_products_productId",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropColumn(
                name: "DateShipped",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderProduct",
                newName: "Orderproduct");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_productId",
                table: "Orderproduct",
                newName: "IX_Orderproduct_productId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderproduct",
                table: "Orderproduct",
                columns: new[] { "orderId", "productId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderproduct_Orders_orderId",
                table: "Orderproduct",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderproduct_product_productId",
                table: "Orderproduct",
                column: "productId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
