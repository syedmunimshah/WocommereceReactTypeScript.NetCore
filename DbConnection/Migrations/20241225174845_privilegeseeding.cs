using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbConnection.Migrations
{
    /// <inheritdoc />
    public partial class privilegeseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Privileges",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Privileges",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "Id", "CreateAt", "IsActive", "Slug", "Type", "UpdateAt", "UrlPath" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(8), true, "user-Register", "Post", null, "Auth/Register" },
                    { 2, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(964), true, "user-GellAll", "Get", null, "Auth/GellAll" },
                    { 3, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(966), true, "user-UpdateRegister", "Post", null, "Auth/UpdateRegister" },
                    { 4, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(969), true, "user-FindUserById", "Get", null, "Auth/FindUserById" },
                    { 5, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(971), true, "user-DeleteUser", "Delete", null, "Auth/DeleteUser" },
                    { 6, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(973), true, "user-Login", "Post", null, "Auth/Login" },
                    { 7, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(976), true, "Admin", "Get", null, "Auth/Admin" },
                    { 8, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(977), true, "User", "Get", null, "Auth/User" },
                    { 9, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(979), true, "Hr", "Get", null, "Auth/Hr" },
                    { 10, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(981), true, "Role-AddRole", "Post", null, "Role/AddRole" },
                    { 11, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(983), true, "Role-GellAll", "Get", null, "Role/GellAll" },
                    { 12, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(984), true, "Role-UpdateRole", "Post", null, "Role/UpdateRole" },
                    { 13, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(986), true, "Role-FindRoleById", "Get", null, "Role/FindRoleById" },
                    { 14, new DateTime(2024, 12, 25, 17, 48, 42, 788, DateTimeKind.Utc).AddTicks(988), true, "Role-Delete", "Delete", null, "Role/Delete" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Privileges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateAt",
                table: "Privileges",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
