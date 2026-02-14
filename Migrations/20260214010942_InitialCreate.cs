using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026_sistem_peminjaman_ruangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peminjaman",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaPeminjam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ruangan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TanggalPeminjaman = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Keperluan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peminjaman", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Peminjaman",
                columns: new[] { "Id", "Keperluan", "NamaPeminjam", "Ruangan", "Status", "TanggalPeminjaman" },
                values: new object[,]
                {
                    { 1, "Praktikum Tambahan", "Budi Santoso", "Lab Komputer 1", "Menunggu", new DateTime(2026, 2, 15, 8, 9, 38, 482, DateTimeKind.Local).AddTicks(8533) },
                    { 2, "Seminar Mahasiswa", "Siti Aminah", "Aula Besar", "Disetujui", new DateTime(2026, 2, 17, 8, 9, 38, 484, DateTimeKind.Local).AddTicks(6134) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peminjaman");
        }
    }
}
