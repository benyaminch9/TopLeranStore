using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DataLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ActiveCode",
                table: "Users",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "WalletTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false),
                    TypeTitle = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    IsPay = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    WalletTypeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wallets_WalletTypes_WalletTypeTypeId",
                        column: x => x.WalletTypeTypeId,
                        principalTable: "WalletTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletTypeTypeId",
                table: "Wallets",
                column: "WalletTypeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "WalletTypes");

            migrationBuilder.AlterColumn<int>(
                name: "UserName",
                table: "Users",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "Users",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Users",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ActiveCode",
                table: "Users",
                type: "int",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
