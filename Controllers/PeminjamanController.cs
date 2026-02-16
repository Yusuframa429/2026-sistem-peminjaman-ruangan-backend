using Microsoft.AspNetCore.Mvc;
using _2026_sistem_peminjaman_ruangan_backend.Models;
using _2026_sistem_peminjaman_ruangan_backend.DTOs;
using _2026_sistem_peminjaman_ruangan_backend.Interfaces;

namespace _2026_sistem_peminjaman_ruangan_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : ControllerBase
    {
        private readonly IPeminjamanService _peminjamanService;

        // Controller cuma panggil Service, gak nyentuh DbContext lagi!
        public PeminjamanController(IPeminjamanService peminjamanService)
        {
            _peminjamanService = peminjamanService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjaman(string? search, string? status, string? sort)
        {
            var data = await _peminjamanService.GetPeminjamanAsync(search, status, sort);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Peminjaman>> PostPeminjaman(CreatePeminjamanDto request)
        {
            var peminjaman = await _peminjamanService.CreatePeminjamanAsync(request);
            return CreatedAtAction(nameof(GetPeminjaman), new { id = peminjaman.Id }, peminjaman);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string statusBaru)
        {
            var success = await _peminjamanService.UpdateStatusAsync(id, statusBaru);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeminjaman(int id)
        {
            var success = await _peminjamanService.DeletePeminjamanAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}