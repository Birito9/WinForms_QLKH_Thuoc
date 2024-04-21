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
    public class ChiTietThuocController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public ChiTietThuocController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietThuoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietThuoc>>> GetChiTietThuoc()
        {
          if (_context.ChiTietThuoc == null)
          {
              return NotFound();
          }
            return await _context.ChiTietThuoc.ToListAsync();
        }

        // GET: api/ChiTietThuoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietThuoc>> GetChiTietThuoc(string id)
        {
          if (_context.ChiTietThuoc == null)
          {
              return NotFound();
          }
            var chiTietThuoc = await _context.ChiTietThuoc.FindAsync(id);

            if (chiTietThuoc == null)
            {
                return NotFound();
            }

            return chiTietThuoc;
        }

        // PUT: api/ChiTietThuoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietThuoc(string id, ChiTietThuoc chiTietThuoc)
        {
            if (id != chiTietThuoc.Thuoc_ID)
            {
                return BadRequest();
            }

            _context.Entry(chiTietThuoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietThuocExists(id))
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

        // POST: api/ChiTietThuoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietThuoc>> PostChiTietThuoc(ChiTietThuoc chiTietThuoc)
        {
          if (_context.ChiTietThuoc == null)
          {
              return Problem("Entity set 'QLKH_ThuocContext.ChiTietThuoc'  is null.");
          }
            _context.ChiTietThuoc.Add(chiTietThuoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietThuocExists(chiTietThuoc.Thuoc_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietThuoc", new { id = chiTietThuoc.Thuoc_ID }, chiTietThuoc);
        }

        // DELETE: api/ChiTietThuoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietThuoc(string id)
        {
            if (_context.ChiTietThuoc == null)
            {
                return NotFound();
            }
            var chiTietThuoc = await _context.ChiTietThuoc.FindAsync(id);
            if (chiTietThuoc == null)
            {
                return NotFound();
            }

            _context.ChiTietThuoc.Remove(chiTietThuoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietThuocExists(string id)
        {
            return (_context.ChiTietThuoc?.Any(e => e.Thuoc_ID == id)).GetValueOrDefault();
        }
    }
}
