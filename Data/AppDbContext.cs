using Microsoft.EntityFrameworkCore;
using _2026_sistem_peminjaman_ruangan_backend.Models;

namespace _2026_sistem_peminjaman_ruangan_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Peminjaman> Peminjaman { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peminjaman>().HasData(
                new Peminjaman
                {
                    Id = 1,
                    NamaPeminjam = "Budi Santoso",
                    Ruangan = "Lab Komputer 1",
                    TanggalPeminjaman = new DateTime(2026, 2, 20, 10, 0, 0), 
                    Keperluan = "Praktikum Tambahan",
                    Status = "Menunggu"
                },
                new Peminjaman
                {
                    Id = 2,
                    NamaPeminjam = "Siti Aminah",
                    Ruangan = "Aula Besar",
                    TanggalPeminjaman = new DateTime(2026, 2, 25, 13, 0, 0),
                    Keperluan = "Seminar Mahasiswa",
                    Status = "Disetujui"
                }
            );
        }
    }
}