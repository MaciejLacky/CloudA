using Microsoft.EntityFrameworkCore.Migrations;

namespace CloudA.Data.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Event_EventIdEvent",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_Images_EventIdEvent",
                table: "Image",
                newName: "IX_Image_EventIdEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "IdImages");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Event_EventIdEvent",
                table: "Image",
                column: "EventIdEvent",
                principalTable: "Event",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Event_EventIdEvent",
                table: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_Image_EventIdEvent",
                table: "Images",
                newName: "IX_Images_EventIdEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "IdImages");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Event_EventIdEvent",
                table: "Images",
                column: "EventIdEvent",
                principalTable: "Event",
                principalColumn: "IdEvent",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
