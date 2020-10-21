using Microsoft.EntityFrameworkCore.Migrations;

namespace LogInApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppClientItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(maxLength: 64, nullable: false),
                    PassCode = table.Column<string>(maxLength: 64, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClientItems", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppClientItems_Nick_EmailAddress",
                table: "AppClientItems",
                columns: new[] { "Nick", "EmailAddress" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppClientItems");
        }
    }
}
