using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalYonetimAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAtamalar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisanlar",
                columns: table => new
                {
                    CalisanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Departman = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SicilNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisanlar", x => x.CalisanID);
                });

            migrationBuilder.CreateTable(
                name: "Demirbaslar",
                columns: table => new
                {
                    DemirbasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemirbasAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DemirbasTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demirbaslar", x => x.DemirbasID);
                });

            migrationBuilder.CreateTable(
                name: "Atamalar",
                columns: table => new
                {
                    AtamaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemirbasID = table.Column<int>(type: "int", nullable: false),
                    CalisanID = table.Column<int>(type: "int", nullable: false),
                    AtamaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atamalar", x => x.AtamaID);
                    table.ForeignKey(
                        name: "FK_Atamalar_Calisanlar_CalisanID",
                        column: x => x.CalisanID,
                        principalTable: "Calisanlar",
                        principalColumn: "CalisanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atamalar_Demirbaslar_DemirbasID",
                        column: x => x.DemirbasID,
                        principalTable: "Demirbaslar",
                        principalColumn: "DemirbasID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atamalar_CalisanID",
                table: "Atamalar",
                column: "CalisanID");

            migrationBuilder.CreateIndex(
                name: "IX_Atamalar_DemirbasID",
                table: "Atamalar",
                column: "DemirbasID");

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_SicilNo",
                table: "Calisanlar",
                column: "SicilNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atamalar");

            migrationBuilder.DropTable(
                name: "Calisanlar");

            migrationBuilder.DropTable(
                name: "Demirbaslar");
        }
    }
}
