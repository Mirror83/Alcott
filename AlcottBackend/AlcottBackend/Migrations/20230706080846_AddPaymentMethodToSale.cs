using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcottBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentMethodToSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "PaymentMethod",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Sales");
        }
    }
}
