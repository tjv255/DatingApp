using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class OrgLikeEntityadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgLikes",
                table: "OrgLikes");

            migrationBuilder.DropIndex(
                name: "IX_OrgLikes_OrgId",
                table: "OrgLikes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrgLikes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "OrgLikes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgLikes",
                table: "OrgLikes",
                columns: new[] { "OrgId", "LikedUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrgLikes_OrganizationId",
                table: "OrgLikes",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrgLikes_Organizations_OrganizationId",
                table: "OrgLikes",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrgLikes_Organizations_OrganizationId",
                table: "OrgLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrgLikes",
                table: "OrgLikes");

            migrationBuilder.DropIndex(
                name: "IX_OrgLikes_OrganizationId",
                table: "OrgLikes");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "OrgLikes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrgLikes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrgLikes",
                table: "OrgLikes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrgLikes_OrgId",
                table: "OrgLikes",
                column: "OrgId");
        }
    }
}
