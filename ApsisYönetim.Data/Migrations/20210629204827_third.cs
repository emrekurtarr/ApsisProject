using Microsoft.EntityFrameworkCore.Migrations;

namespace ApsisYönetim.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyCharge_AspNetUsers_UserId",
                table: "MonthlyCharge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyCharge",
                table: "MonthlyCharge");

            migrationBuilder.DropColumn(
                name: "Admin_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Admin_Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Admin_TcNo",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "MonthlyCharge",
                newName: "MonthlyCharges");

            migrationBuilder.RenameIndex(
                name: "IX_MonthlyCharge_UserId",
                table: "MonthlyCharges",
                newName: "IX_MonthlyCharges_UserId");

            migrationBuilder.AddColumn<int>(
                name: "MonthlyChargeID",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyCharges",
                table: "MonthlyCharges",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_MonthlyChargeID",
                table: "Apartments",
                column: "MonthlyChargeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_MonthlyCharges_MonthlyChargeID",
                table: "Apartments",
                column: "MonthlyChargeID",
                principalTable: "MonthlyCharges",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyCharges_AspNetUsers_UserId",
                table: "MonthlyCharges",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_MonthlyCharges_MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyCharges_AspNetUsers_UserId",
                table: "MonthlyCharges");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonthlyCharges",
                table: "MonthlyCharges");

            migrationBuilder.DropColumn(
                name: "MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "MonthlyCharges",
                newName: "MonthlyCharge");

            migrationBuilder.RenameIndex(
                name: "IX_MonthlyCharges_UserId",
                table: "MonthlyCharge",
                newName: "IX_MonthlyCharge_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Admin_Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_TcNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonthlyCharge",
                table: "MonthlyCharge",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyCharge_AspNetUsers_UserId",
                table: "MonthlyCharge",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
