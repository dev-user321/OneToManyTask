using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneToManyTask.Migrations
{
    /// <inheritdoc />
    public partial class ValentineAndValentineTaskTableCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valentines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valentines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ValentineTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValentineId = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValentineTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValentineTasks_Valentines_ValentineId",
                        column: x => x.ValentineId,
                        principalTable: "Valentines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValentineTasks_ValentineId",
                table: "ValentineTasks",
                column: "ValentineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValentineTasks");

            migrationBuilder.DropTable(
                name: "Valentines");
        }
    }
}
