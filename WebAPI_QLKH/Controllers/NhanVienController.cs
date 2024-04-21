using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_QLKH.Models;
using static WebAPI_QLKH.Controllers.KhoController;

namespace WebAPI_QLKH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public NhanVienController(QLKH_ThuocContext context)
        {
            _context = context;
        }
        // GET: api/NhanVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanVien()
        {
            if (_context.NhanVien == null)
            {
                return NotFound();
            }
            return await _context.NhanVien.ToListAsync();
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(string id)
        {
          if (_context.NhanVien == null)
          {
              return NotFound();
          }
            var nhanVien = await _context.NhanVien.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return nhanVien;
        }

        // PUT: api/NhanVien/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(string id, NhanVien nhanVien)
        {
            if (id != nhanVien.NV_ID)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NhanVien
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<NhanVien>>> PostNhanVien([FromBody] List<NhanVien> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var NVList = payloads.Select(payload => new NhanVien
            {
                CN_ID = payload.CN_ID?.Trim() ?? string.Empty,
                UserID = payload.UserID?.Trim() ?? string.Empty,
                NV_Name = payload.NV_Name?.Trim() ?? string.Empty,
                Address = payload.Address?.Trim() ?? string.Empty,
                NV_ID = payload.NV_ID?.Trim() ?? string.Empty,
                BirthDay = payload.BirthDay,
                Phone = payload.Phone ?? string.Empty, 
                Email = payload.Email?.Trim() ?? string.Empty,
                Sex = payload.Sex?.Trim() ?? string.Empty
            }).ToList();

            _context.NhanVien.AddRange(NVList);
            await _context.SaveChangesAsync();

            return NVList;
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanVien(string id)
        {
            if (_context.NhanVien == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan.FindAsync(nhanVien.UserID);
            if (taiKhoan != null)
            {
                _context.TaiKhoan.Remove(taiKhoan);
            }

            _context.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanVienExists(string id)
        {
            return (_context.NhanVien?.Any(e => e.NV_ID == id)).GetValueOrDefault();
        }
    }
}
