using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_sistem_peminjaman_ruangan_backend.Data;
using _2026_sistem_peminjaman_ruangan_backend.Models;
using _2026_sistem_peminjaman_ruangan_backend.DTOs;

namespace _2026_sistem_peminjaman_ruangan_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: Ambil semua data (Riwayat & Penelusuran)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjaman()
        {
            return await _context.Peminjaman.ToListAsync();
        }

        // 2. GET: Ambil detail 1 peminjaman
        [HttpGet("{id}")]
        public async Task<ActionResult<Peminjaman>> GetPeminjaman(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();
            return peminjaman;
        }

        [HttpPost]
        public async Task<ActionResult<Peminjaman>> PostPeminjaman(CreatePeminjamanDto request)
        {
            // Menerapkan data dari DTO ke Model Entity
            var peminjaman = new Peminjaman
            {
                // Tambahkan tanda seru (!) untuk memaksa string tidak null
                NamaPeminjam = request.NamaPeminjam!,
                Ruangan = request.Ruangan!,

                // ERROR UTAMA KAMU DISINI: 
                // Tambahkan .Value untuk mengambil isi tanggalnya
                TanggalPeminjaman = request.TanggalPeminjaman.Value,

                Keperluan = request.Keperluan!,
                Status = "Menunggu"
            };

            _context.Peminjaman.Add(peminjaman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPeminjaman), new { id = peminjaman.Id }, peminjaman);
        }
        // 4. PUT: Update Status (Pengelolaan Status)
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string statusBaru)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();

            peminjaman.Status = statusBaru;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 5. DELETE: Hapus Data
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeminjaman(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();

            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}