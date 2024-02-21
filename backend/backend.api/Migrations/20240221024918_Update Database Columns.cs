using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDtm",
                table: "ItemEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "ItemEntities",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ItemEntities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "ItemEntities",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDtm",
                table: "ItemEntities");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "ItemEntities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemEntities");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "ItemEntities");
        }
    }
}
