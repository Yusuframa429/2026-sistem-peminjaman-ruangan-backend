using System.ComponentModel.DataAnnotations;

namespace _2026_sistem_peminjaman_ruangan_backend.Models
{
    public class Peminjaman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NamaPeminjam { get; set; } = string.Empty;

        [Required]
        public string Ruangan { get; set; } = string.Empty; // Contoh: "Aula Utama"

        public DateTime TanggalPeminjaman { get; set; }

        [Required]
        public string Keperluan { get; set; } = string.Empty;

        // Status: "Menunggu", "Disetujui", "Ditolak"
        public string Status { get; set; } = "Menunggu";
    }
}