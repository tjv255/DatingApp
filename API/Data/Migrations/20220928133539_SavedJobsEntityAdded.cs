using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class SavedJobsEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSave_AspNetUsers_SavedUserId",
                table: "JobSave");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSave_Jobs_JobId",
                table: "JobSave");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSave",
                table: "JobSave");

            migrationBuilder.RenameTable(
                name: "JobSave",
                newName: "SavedJobs");

            migrationBuilder.RenameColumn(
                name: "SavedUserId",
                table: "SavedJobs",
                newName: "SourceUserId");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "SavedJobs",
                newName: "SavedJobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSave_SavedUserId",
                table: "SavedJobs",
                newName: "IX_SavedJobs_SourceUserId");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "SavedJobs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedJobs",
                table: "SavedJobs",
                columns: new[] { "SavedJobId", "SourceUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_AppUserId",
                table: "SavedJobs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobs_AspNetUsers_AppUserId",
                table: "SavedJobs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobs_AspNetUsers_SourceUserId",
                table: "SavedJobs",
                column: "SourceUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJobs_Jobs_SavedJobId",
                table: "SavedJobs",
                column: "SavedJobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobs_AspNetUsers_AppUserId",
                table: "SavedJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobs_AspNetUsers_SourceUserId",
                table: "SavedJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJobs_Jobs_SavedJobId",
                table: "SavedJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedJobs",
                table: "SavedJobs");

            migrationBuilder.DropIndex(
                name: "IX_SavedJobs_AppUserId",
                table: "SavedJobs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SavedJobs");

            migrationBuilder.RenameTable(
                name: "SavedJobs",
                newName: "JobSave");

            migrationBuilder.RenameColumn(
                name: "SourceUserId",
                table: "JobSave",
                newName: "SavedUserId");

            migrationBuilder.RenameColumn(
                name: "SavedJobId",
                table: "JobSave",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_SavedJobs_SourceUserId",
                table: "JobSave",
                newName: "IX_JobSave_SavedUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSave",
                table: "JobSave",
                columns: new[] { "JobId", "SavedUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSave_AspNetUsers_SavedUserId",
                table: "JobSave",
                column: "SavedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSave_Jobs_JobId",
                table: "JobSave",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
