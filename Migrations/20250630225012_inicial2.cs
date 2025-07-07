using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjct.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_Seller_SallerId",
                table: "SalesRecords");

            migrationBuilder.RenameColumn(
                name: "SallerId",
                table: "SalesRecords",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecords_SallerId",
                table: "SalesRecords",
                newName: "IX_SalesRecords_SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_Seller_SellerId",
                table: "SalesRecords",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_Seller_SellerId",
                table: "SalesRecords");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "SalesRecords",
                newName: "SallerId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecords_SellerId",
                table: "SalesRecords",
                newName: "IX_SalesRecords_SallerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_Seller_SallerId",
                table: "SalesRecords",
                column: "SallerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
