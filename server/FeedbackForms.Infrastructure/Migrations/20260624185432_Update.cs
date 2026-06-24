using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackForms.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "body",
                table: "topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "topics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "answers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "answers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "text",
                table: "answers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "answers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "body",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "title",
                table: "topics");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "email",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "text",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "answers");
        }
    }
}
