using _2026_sistem_peminjaman_ruangan_backend.DTOs;
using _2026_sistem_peminjaman_ruangan_backend.Models;

namespace _2026_sistem_peminjaman_ruangan_backend.Interfaces
{
    public interface IPeminjamanService
    {
        Task<IEnumerable<Peminjaman>> GetPeminjamanAsync(string? search, string? status, string? sort);
        Task<Peminjaman> CreatePeminjamanAsync(CreatePeminjamanDto request);
        Task<bool> UpdateStatusAsync(int id, string statusBaru);
        Task<bool> DeletePeminjamanAsync(int id);
    }
}