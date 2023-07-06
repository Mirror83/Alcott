using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcottBackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInvalidNavigationPropertyr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderDetail_OrderDetailId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_OrderDetailId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "OrderDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "OrderDetail",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderDetailId",
                table: "OrderDetail",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderDetail_OrderDetailId",
                table: "OrderDetail",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }
    }
}
