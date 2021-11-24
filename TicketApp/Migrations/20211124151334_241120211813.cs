using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketApp.Migrations
{
    public partial class _241120211813 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerID",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Ticket",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CustomerID",
                table: "Ticket",
                newName: "IX_Ticket_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Customer_CustomerId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Ticket",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                newName: "IX_Ticket_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Customer_CustomerID",
                table: "Ticket",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
