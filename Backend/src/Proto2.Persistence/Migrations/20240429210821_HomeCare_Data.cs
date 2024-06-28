using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proto2.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HomeCare_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Person",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NeighborhoodName",
                table: "Person",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonAdressNumber",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonAdressStreetName",
                table: "Person",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PersonFirstEntryDate",
                table: "Person",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Person",
                type: "varchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Person",
                type: "varchar(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeCareCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareCompanies", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HomeCareContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    HomeCareCompanyId = table.Column<int>(type: "int", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: true),
                    ContactData = table.Column<string>(type: "longtext", nullable: true),
                    ContactName = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCareContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeCareContacts_HomeCareCompanies_HomeCareCompanyId",
                        column: x => x.HomeCareCompanyId,
                        principalTable: "HomeCareCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCareContacts_HomeCareCompanyId",
                table: "HomeCareContacts",
                column: "HomeCareCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeCareContacts");

            migrationBuilder.DropTable(
                name: "HomeCareCompanies");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "NeighborhoodName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonAdressNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonAdressStreetName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonFirstEntryDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Person");
        }
    }
}
