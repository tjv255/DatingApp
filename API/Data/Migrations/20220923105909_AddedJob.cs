using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddedJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_AppUserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUrl",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrgId",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProvinceOrState",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SkillsRequired",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jobs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobPosterId",
                table: "Jobs",
                column: "JobPosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_JobPosterId",
                table: "Jobs",
                column: "JobPosterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_AspNetUsers_JobPosterId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobPosterId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ApplicationUrl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ProvinceOrState",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SkillsRequired",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Jobs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AppUserId",
                table: "Jobs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_AspNetUsers_AppUserId",
                table: "Jobs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
