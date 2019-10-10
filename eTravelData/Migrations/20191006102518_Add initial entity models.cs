using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTravelData.Migrations
{
    public partial class Addinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Klijents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Klijents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Klijents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "Klijents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "Klijents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaUrl",
                table: "Klijents",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UplataId",
                table: "Klijents",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Putovanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false),
                    Destinacija = table.Column<string>(nullable: false),
                    MaxUcesnika = table.Column<int>(nullable: false),
                    DatumPolaska = table.Column<DateTime>(nullable: false),
                    DatumPovratka = table.Column<DateTime>(nullable: false),
                    DatumBookiranja = table.Column<DateTime>(nullable: false),
                    DjecaBool = table.Column<bool>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false),
                    UplataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Putovanja_Uplate_UplataId",
                        column: x => x.UplataId,
                        principalTable: "Uplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agencije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: false),
                    Telefon = table.Column<string>(nullable: false),
                    Manager = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: false),
                    SlikaUrl = table.Column<string>(nullable: true),
                    PutovanjeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencije_Putovanja_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klijents_PutovanjeId",
                table: "Klijents",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijents_UplataId",
                table: "Klijents",
                column: "UplataId");

            migrationBuilder.CreateIndex(
                name: "IX_Agencije_PutovanjeId",
                table: "Agencije",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Putovanja_UplataId",
                table: "Putovanja",
                column: "UplataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Klijents_Putovanja_PutovanjeId",
                table: "Klijents",
                column: "PutovanjeId",
                principalTable: "Putovanja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Klijents_Uplate_UplataId",
                table: "Klijents",
                column: "UplataId",
                principalTable: "Uplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klijents_Putovanja_PutovanjeId",
                table: "Klijents");

            migrationBuilder.DropForeignKey(
                name: "FK_Klijents_Uplate_UplataId",
                table: "Klijents");

            migrationBuilder.DropTable(
                name: "Agencije");

            migrationBuilder.DropTable(
                name: "Putovanja");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropIndex(
                name: "IX_Klijents_PutovanjeId",
                table: "Klijents");

            migrationBuilder.DropIndex(
                name: "IX_Klijents_UplataId",
                table: "Klijents");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "Klijents");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "Klijents");

            migrationBuilder.DropColumn(
                name: "SlikaUrl",
                table: "Klijents");

            migrationBuilder.DropColumn(
                name: "UplataId",
                table: "Klijents");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Klijents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "Klijents",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Klijents",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
