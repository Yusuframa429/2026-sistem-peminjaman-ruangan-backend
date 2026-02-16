using Microsoft.EntityFrameworkCore;
using _2026_sistem_peminjaman_ruangan_backend.Data;
using _2026_sistem_peminjaman_ruangan_backend.Models;
using _2026_sistem_peminjaman_ruangan_backend.DTOs;
using _2026_sistem_peminjaman_ruangan_backend.Interfaces;

namespace _2026_sistem_peminjaman_ruangan_backend.Services
{
    public class PeminjamanService : IPeminjamanService
    {
        private readonly AppDbContext _context;

        public PeminjamanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Peminjaman>> GetPeminjamanAsync(string? search, string? status, string? sort)
        {
            var query = _context.Peminjaman.AsQueryable();

            // Logika Pencarian
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NamaPeminjam.ToLower().Contains(search.ToLower()) || 
                                         p.Keperluan.ToLower().Contains(search.ToLower()) ||
                                         p.Ruangan.ToLower().Contains(search.ToLower()));
            }

            // Logika Filter Status
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status == status);
            }

            // Logika Sorting
            switch (sort)
            {
                case "terlama":
                    query = query.OrderBy(p => p.TanggalPeminjaman);
                    break;
                case "nama_az":
                    query = query.OrderBy(p => p.NamaPeminjam);
                    break;
                case "nama_za":
                    query = query.OrderByDescending(p => p.NamaPeminjam);
                    break;
                default:
                    query = query.OrderByDescending(p => p.TanggalPeminjaman);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<Peminjaman> CreatePeminjamanAsync(CreatePeminjamanDto request)
        {
            var peminjaman = new Peminjaman
            {
                NamaPeminjam = request.NamaPeminjam!,
                Ruangan = request.Ruangan!,
                TanggalPeminjaman = request.TanggalPeminjaman.Value,
                Keperluan = request.Keperluan!,
                Status = "Menunggu"
            };

            _context.Peminjaman.Add(peminjaman);
            await _context.SaveChangesAsync();
            return peminjaman;
        }

        public async Task<bool> UpdateStatusAsync(int id, string statusBaru)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return false;

            peminjaman.Status = statusBaru;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePeminjamanAsync(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return false;

            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}