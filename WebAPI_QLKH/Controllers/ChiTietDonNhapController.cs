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
    public class ChiTietDonNhapController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public ChiTietDonNhapController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietDonNhap
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDonNhap>>> GetChiTietDonNhap()
        {
          if (_context.ChiTietDonNhap == null)
          {
              return NotFound();
          }
            return await _context.ChiTietDonNhap.ToListAsync();
        }

        // GET: api/ChiTietDonNhap/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDonNhap>> GetChiTietDonNhap(string id)
        {
          if (_context.ChiTietDonNhap == null)
          {
              return NotFound();
          }
            var chiTietDonNhap = await _context.ChiTietDonNhap.FindAsync(id);

            if (chiTietDonNhap == null)
            {
                return NotFound();
            }

            return chiTietDonNhap;
        }

        // PUT: api/ChiTietDonNhap/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDonNhap(string id, ChiTietDonNhap chiTietDonNhap)
        {
            if (id != chiTietDonNhap.DNhap_ID)
            {
                return BadRequest();
            }

            _context.Entry(chiTietDonNhap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDonNhapExists(id))
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

        // POST: api/ChiTietDonNhap
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietDonNhap>> PostChiTietDonNhap(ChiTietDonNhap chiTietDonNhap)
        {
          if (_context.ChiTietDonNhap == null)
          {
              return Problem("Entity set 'QLKH_ThuocContext.ChiTietDonNhap'  is null.");
          }
            _context.ChiTietDonNhap.Add(chiTietDonNhap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietDonNhapExists(chiTietDonNhap.Lo_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietDonNhap", new { id = chiTietDonNhap.Lo_ID }, chiTietDonNhap);
        }

        // DELETE: api/ChiTietDonNhap/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDonNhap(string id)
        {
            if (_context.ChiTietDonNhap == null)
            {
                return NotFound();
            }
            var chiTietDonNhap = await _context.ChiTietDonNhap.FindAsync(id);
            if (chiTietDonNhap == null)
            {
                return NotFound();
            }

            _context.ChiTietDonNhap.Remove(chiTietDonNhap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietDonNhapExists(string id)
        {
            return (_context.ChiTietDonNhap?.Any(e => e.Lo_ID == id)).GetValueOrDefault();
        }
    }
}
