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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjaman(string? q, string? status)
        {
            var query = _context.Peminjaman.AsQueryable();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(x => x.NamaPeminjam.Contains(q) || x.Ruangan.Contains(q));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(x => x.Status == status);
            }
            return await query.ToListAsync();
        }
        
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

            return CreatedAtAction(nameof(GetPeminjaman), new { id = peminjaman.Id }, peminjaman);
        }
        
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string statusBaru)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();

            peminjaman.Status = statusBaru;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
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