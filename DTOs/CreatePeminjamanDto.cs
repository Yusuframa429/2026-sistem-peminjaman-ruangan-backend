using System.ComponentModel.DataAnnotations;

namespace _2026_sistem_peminjaman_ruangan_backend.DTOs
{
    public class CreatePeminjamanDto
    {
        [Required(ErrorMessage = "Nama Peminjam wajib diisi!")]
        public string? NamaPeminjam { get; set; }

        [Required(ErrorMessage = "Ruangan wajib diisi!")]
        public string? Ruangan { get; set; }
        
        [Required(ErrorMessage = "Tanggal harus diisi!")]
        public DateTime? TanggalPeminjaman { get; set; }

        [Required(ErrorMessage = "Keperluan wajib diisi!")]
        public string? Keperluan { get; set; }
    }
}