using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketApp.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Ticket",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                newName: "IX_Ticket_EmployeeID");

            migrationBuilder.AddColumn<string>(
                name: "EmployeId",
                table: "Manager",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employee_EmployeeID",
                table: "Ticket",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employee_EmployeeID",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "Manager");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Ticket",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EmployeeID",
                table: "Ticket",
                newName: "IX_Ticket_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
