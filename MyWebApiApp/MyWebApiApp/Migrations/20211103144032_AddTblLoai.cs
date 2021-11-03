using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApiApp.Migrations
{
    public partial class AddTblLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoai",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loai",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai", x => x.MaLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa",
                column: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa",
                column: "MaLoai",
                principalTable: "Loai",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Loai_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "Loai");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_MaLoai",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "MaLoai",
                table: "HangHoa");
        }
    }
}
