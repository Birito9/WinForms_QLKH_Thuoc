using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuocController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public ThuocController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/Thuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thuoc>>> GetThuoc()
        {
          if (_context.Thuoc == null)
          {
              return NotFound();
          }
            return await _context.Thuoc.ToListAsync();
        }

        // GET: api/Thuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thuoc>> GetThuoc(string id)
        {
          if (_context.Thuoc == null)
          {
              return NotFound();
          }
            var thuoc = await _context.Thuoc.FindAsync(id);

            if (thuoc == null)
            {
                return NotFound();
            }

            return thuoc;
        }

        // PUT: api/Thuoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuoc(string id, Thuoc thuoc)
        {
            if (id != thuoc.Thuoc_ID)
            {
                return BadRequest();
            }

            _context.Entry(thuoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuocExists(id))
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

        // POST: api/Thuoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Thuoc>>> PostThuoc([FromBody] List<Thuoc> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var thuocList = payloads.Select(payload => new Thuoc
            {
                Thuoc_ID = payload.Thuoc_ID?.Trim() ?? string.Empty,
                Nhom_ID = payload.Nhom_ID?.Trim() ?? string.Empty,
                Thuoc_Name = payload.Thuoc_Name?.Trim() ?? string.Empty
            }).ToList();

            _context.Thuoc.AddRange(thuocList);
            await _context.SaveChangesAsync();

            return thuocList;
        }

        // DELETE: api/Thuoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuoc(string id)
        {
            if (_context.Thuoc == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuoc.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }

            var ctdx = await _context.ChiTietDonXuat.FirstOrDefaultAsync(ct => ct.Thuoc.Thuoc_ID == id);
            if (ctdx != null)
            {
                _context.ChiTietDonXuat.Remove(ctdx);
            }

            var ctdn = await _context.ChiTietDonNhap.FirstOrDefaultAsync(ct => ct.Thuoc.Thuoc_ID == id);
            if (ctdn != null)
            {
                _context.ChiTietDonNhap.Remove(ctdn);
            }

            var ctt = await _context.ChiTietThuoc.FirstOrDefaultAsync(ct => ct.Thuoc.Thuoc_ID == id);
            if (ctt != null)
            {
                _context.ChiTietThuoc.Remove(ctt);
            }

            _context.Thuoc.Remove(thuoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuocExists(string id)
        {
            return (_context.Thuoc?.Any(e => e.Thuoc_ID == id)).GetValueOrDefault();
        }
    }
}
