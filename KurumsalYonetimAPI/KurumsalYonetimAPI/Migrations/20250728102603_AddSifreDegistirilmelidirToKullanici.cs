using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KurumsalYonetimAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSifreDegistirilmelidirToKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SifreDegistirilmelidir",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SifreDegistirilmelidir",
                table: "Kullanicilar");
        }
    }
}
