using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingOrg.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addisselected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cameramen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameramen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfTheWedding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfSigningTheContract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrideId = table.Column<int>(type: "int", nullable: false),
                    GroomId = table.Column<int>(type: "int", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: true),
                    CameramanId = table.Column<int>(type: "int", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weddings_Brides_BrideId",
                        column: x => x.BrideId,
                        principalTable: "Brides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weddings_Cameramen_CameramanId",
                        column: x => x.CameramanId,
                        principalTable: "Cameramen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Weddings_Grooms_GroomId",
                        column: x => x.GroomId,
                        principalTable: "Grooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Weddings_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Weddings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_BrideId",
                table: "Weddings",
                column: "BrideId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_CameramanId",
                table: "Weddings",
                column: "CameramanId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_GroomId",
                table: "Weddings",
                column: "GroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_PhotographerId",
                table: "Weddings",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Weddings_RestaurantId",
                table: "Weddings",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "Brides");

            migrationBuilder.DropTable(
                name: "Cameramen");

            migrationBuilder.DropTable(
                name: "Grooms");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
