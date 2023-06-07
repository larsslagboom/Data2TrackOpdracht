﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data2TrackApiOpdracht.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoiLocations",
                columns: table => new
                {
                    PoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Radius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiLocations", x => x.PoiId);
                });

            migrationBuilder.CreateTable(
                name: "PoiTypesAndTitles",
                columns: table => new
                {
                    PoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiTypesAndTitles", x => x.PoiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoiLocations");

            migrationBuilder.DropTable(
                name: "PoiTypesAndTitles");
        }
    }
}
