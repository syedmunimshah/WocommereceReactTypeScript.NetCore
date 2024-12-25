using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbConnection.Migrations
{
    /// <inheritdoc />
    public partial class entityroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePrivileges_Privileges_PrivilegesId",
                table: "RolePrivileges");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePrivileges_Roles_RoleId",
                table: "RolePrivileges");

            migrationBuilder.DropIndex(
                name: "IX_RolePrivileges_PrivilegesId",
                table: "RolePrivileges");

            migrationBuilder.DropIndex(
                name: "IX_RolePrivileges_RoleId",
                table: "RolePrivileges");

            migrationBuilder.CreateTable(
                name: "PrivilegesRolePrivileges",
                columns: table => new
                {
                    PrivilegesId = table.Column<int>(type: "int", nullable: false),
                    RolePrivilegesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivilegesRolePrivileges", x => new { x.PrivilegesId, x.RolePrivilegesId });
                    table.ForeignKey(
                        name: "FK_PrivilegesRolePrivileges_Privileges_PrivilegesId",
                        column: x => x.PrivilegesId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivilegesRolePrivileges_RolePrivileges_RolePrivilegesId",
                        column: x => x.RolePrivilegesId,
                        principalTable: "RolePrivileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRolePrivileges",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RolePrivilegesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRolePrivileges", x => new { x.RoleId, x.RolePrivilegesId });
                    table.ForeignKey(
                        name: "FK_RoleRolePrivileges_RolePrivileges_RolePrivilegesId",
                        column: x => x.RolePrivilegesId,
                        principalTable: "RolePrivileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleRolePrivileges_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1349));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1358));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1365));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 18, 34, 35, 936, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.CreateIndex(
                name: "IX_PrivilegesRolePrivileges_RolePrivilegesId",
                table: "PrivilegesRolePrivileges",
                column: "RolePrivilegesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRolePrivileges_RolePrivilegesId",
                table: "RoleRolePrivileges",
                column: "RolePrivilegesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivilegesRolePrivileges");

            migrationBuilder.DropTable(
                name: "RoleRolePrivileges");

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 392, DateTimeKind.Utc).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(824));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(826));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(828));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(834));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(836));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(838));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(841));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "Privileges",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2024, 12, 25, 17, 50, 58, 393, DateTimeKind.Utc).AddTicks(844));

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_PrivilegesId",
                table: "RolePrivileges",
                column: "PrivilegesId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_RoleId",
                table: "RolePrivileges",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePrivileges_Privileges_PrivilegesId",
                table: "RolePrivileges",
                column: "PrivilegesId",
                principalTable: "Privileges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePrivileges_Roles_RoleId",
                table: "RolePrivileges",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
