using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026_sistem_peminjaman_ruangan_backend.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peminjaman",
                keyColumn: "Id",
                keyValue: 1,
                column: "TanggalPeminjaman",
                value: new DateTime(2026, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Peminjaman",
                keyColumn: "Id",
                keyValue: 2,
                column: "TanggalPeminjaman",
                value: new DateTime(2026, 2, 25, 13, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Peminjaman",
                keyColumn: "Id",
                keyValue: 1,
                column: "TanggalPeminjaman",
                value: new DateTime(2026, 2, 15, 8, 9, 38, 482, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "Peminjaman",
                keyColumn: "Id",
                keyValue: 2,
                column: "TanggalPeminjaman",
                value: new DateTime(2026, 2, 17, 8, 9, 38, 484, DateTimeKind.Local).AddTicks(6134));
        }
    }
}
