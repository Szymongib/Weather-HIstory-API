using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WeatherHistoryAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherDataEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cloudiness = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    MainWeather = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxTemperature = table.Column<double>(type: "float", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinTemperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    RainVolume = table.Column<int>(type: "int", nullable: true),
                    SnowVolume = table.Column<int>(type: "int", nullable: true),
                    Sunrise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sunset = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    WeatherDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WindSpeed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDataEntries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherDataEntries");
        }
    }
}
