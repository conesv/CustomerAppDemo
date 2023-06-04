using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "OrderProducts");
        }
    }
}
