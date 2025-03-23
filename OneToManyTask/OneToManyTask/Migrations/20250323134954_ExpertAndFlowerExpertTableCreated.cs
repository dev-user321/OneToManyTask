using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyTask.Migrations
{
    /// <inheritdoc />
    public partial class ExpertAndFlowerExpertTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowerExperts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerExperts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpertProfession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowerExpertId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_FlowerExperts_FlowerExpertId",
                        column: x => x.FlowerExpertId,
                        principalTable: "FlowerExperts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experts_FlowerExpertId",
                table: "Experts",
                column: "FlowerExpertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "FlowerExperts");
        }
    }
}
