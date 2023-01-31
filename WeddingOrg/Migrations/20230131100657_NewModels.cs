using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingOrg.Migrations
{
    /// <inheritdoc />
    public partial class NewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Cameramen_CameramanId",
                table: "Weddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Photographers_PhotographerId",
                table: "Weddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Restaurants_RestaurantId",
                table: "Weddings");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Weddings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "Weddings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CameramanId",
                table: "Weddings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Cameramen_CameramanId",
                table: "Weddings",
                column: "CameramanId",
                principalTable: "Cameramen",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Photographers_PhotographerId",
                table: "Weddings",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Restaurants_RestaurantId",
                table: "Weddings",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Cameramen_CameramanId",
                table: "Weddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Photographers_PhotographerId",
                table: "Weddings");

            migrationBuilder.DropForeignKey(
                name: "FK_Weddings_Restaurants_RestaurantId",
                table: "Weddings");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Weddings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "Weddings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CameramanId",
                table: "Weddings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Cameramen_CameramanId",
                table: "Weddings",
                column: "CameramanId",
                principalTable: "Cameramen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Photographers_PhotographerId",
                table: "Weddings",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weddings_Restaurants_RestaurantId",
                table: "Weddings",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
