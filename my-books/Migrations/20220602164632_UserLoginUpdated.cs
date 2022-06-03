using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class UserLoginUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "UserInfos");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserInfos",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "UserInfos",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserInfos",
                newName: "GivenName");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "UserInfos");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "UserInfos",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserInfos",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "UserInfos",
                newName: "Email");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "UserInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
