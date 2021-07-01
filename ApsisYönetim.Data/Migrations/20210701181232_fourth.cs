using Microsoft.EntityFrameworkCore.Migrations;

namespace ApsisYönetim.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_MonthlyCharges_MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyCharges_AspNetUsers_UserId",
                table: "MonthlyCharges");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyCharges_UserId",
                table: "MonthlyCharges");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "MonthlyCharges");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MonthlyCharges");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MonthlyChargeID",
                table: "Apartments");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentID",
                table: "MonthlyCharges",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCharges_ApartmentID",
                table: "MonthlyCharges",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyCharges_Apartments_ApartmentID",
                table: "MonthlyCharges",
                column: "ApartmentID",
                principalTable: "Apartments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlyCharges_Apartments_ApartmentID",
                table: "MonthlyCharges");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyCharges_ApartmentID",
                table: "MonthlyCharges");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ApartmentID",
                table: "MonthlyCharges");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "MonthlyCharges",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MonthlyCharges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthlyChargeID",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCharges_UserId",
                table: "MonthlyCharges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

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
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlyCharges_AspNetUsers_UserId",
                table: "MonthlyCharges",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
