using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.DataAccess.Migrations
{
    public partial class moviedbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imageurl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moviecosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstPhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddlePhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviecosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moviecosts_movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "moviedetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moviedetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_moviedetails_movies_Id",
                        column: x => x.Id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_moviecosts_MovieId",
                table: "moviecosts",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moviecosts");

            migrationBuilder.DropTable(
                name: "moviedetails");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
