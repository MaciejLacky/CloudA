using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudA.Data.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    IdImages = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PathUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEvent = table.Column<int>(type: "int", nullable: false),
                    EventIdEvent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.IdImages);
                    table.ForeignKey(
                        name: "FK_Images_Event_EventIdEvent",
                        column: x => x.EventIdEvent,
                        principalTable: "Event",
                        principalColumn: "IdEvent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventIdEvent",
                table: "Images",
                column: "EventIdEvent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
