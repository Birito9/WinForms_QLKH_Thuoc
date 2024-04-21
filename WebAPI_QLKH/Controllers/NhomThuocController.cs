using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using WebAPI_QLKH.Models;

namespace WebAPI_QLKH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomThuocController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public NhomThuocController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/NhomThuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhomThuoc>>> GetNhomThuoc()
        {
          if (_context.NhomThuoc == null)
          {
              return NotFound();
          }
            return await _context.NhomThuoc.ToListAsync();
        }

        // GET: api/NhomThuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhomThuoc>> GetNhomThuoc(string id)
        {
          if (_context.NhomThuoc == null)
          {
              return NotFound();
          }
            var nhomThuoc = await _context.NhomThuoc.FindAsync(id);

            if (nhomThuoc == null)
            {
                return NotFound();
            }

            return nhomThuoc;
        }

        // PUT: api/NhomThuoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhomThuoc(string id, NhomThuoc nhomThuoc)
        {
            if (id != nhomThuoc.Nhom_ID)
            {
                return BadRequest();
            }

            _context.Entry(nhomThuoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomThuocExists(id))
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

        // POST: api/NhomThuoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<NhomThuoc>>> PostNhomThuoc([FromBody] List<NhomThuoc> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var NTList = payloads.Select(payload => new NhomThuoc
            {
                Nhom_ID = payload.Nhom_ID?.Trim() ?? string.Empty,
                Nhom_Name = payload.Nhom_Name?.Trim() ?? string.Empty,
                Description = payload.Description?.Trim() ?? string.Empty
            }).ToList();

            _context.NhomThuoc.AddRange(NTList);
            await _context.SaveChangesAsync();

            return NTList;
        }

        // DELETE: api/NhomThuoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhomThuoc(string id)
        {
            if (_context.NhomThuoc == null)
            {
                return NotFound();
            }

            var nhomThuoc = await _context.NhomThuoc.FindAsync(id);
            if (nhomThuoc == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuoc.FirstOrDefaultAsync(t => t.Nhom_ID == id);
            if (thuoc != null)
            {
                thuoc.Nhom_ID = null;
            }

            _context.NhomThuoc.Remove(nhomThuoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhomThuocExists(string id)
        {
            return (_context.NhomThuoc?.Any(e => e.Nhom_ID == id)).GetValueOrDefault();
        }
    }
}
