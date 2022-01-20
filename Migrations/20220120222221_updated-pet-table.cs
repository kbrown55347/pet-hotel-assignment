using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_bakery.Migrations
{
    public partial class updatedpettable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerId",
                table: "Pets",
                newName: "petOwnerid");

            migrationBuilder.RenameColumn(
                name: "PetColor",
                table: "Pets",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "breed");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerId",
                table: "Pets",
                newName: "IX_Pets_petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pets",
                newName: "petOwnerId");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Pets",
                newName: "PetColor");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "Pets",
                newName: "PetBreed");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                newName: "IX_Pets_petOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets",
                column: "petOwnerId",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
