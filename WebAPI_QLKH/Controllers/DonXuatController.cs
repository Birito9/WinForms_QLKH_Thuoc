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
    public class DonXuatController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public DonXuatController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/DonXuat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonXuat>>> GetDonXuat()
        {
          if (_context.DonXuat == null)
          {
              return NotFound();
          }
            return await _context.DonXuat.ToListAsync();
        }

        // GET: api/DonXuat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonXuat>> GetDonXuat(string id)
        {
            if (_context.DonXuat== null)
            {
                return NotFound();
            }
            var donXuat = await _context.DonXuat.FindAsync(id);
            if (donXuat == null)
            {
                return NotFound();
            }

            var ctdx = await _context.ChiTietDonXuat.FindAsync(donXuat.DXuat_ID);
            if (ctdx != null)
            {
                _context.ChiTietDonXuat.Remove(ctdx);
            }

            _context.DonXuat.Remove(donXuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/DonXuat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonXuat(string id, DonXuat donXuat)
        {
            if (id != donXuat.DXuat_ID)
            {
                return BadRequest();
            }

            _context.Entry(donXuat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonXuatExists(id))
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

        // POST: api/DonXuat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<DonXuat>>> PostDonXuat([FromBody] List<DonXuat> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var DXList = payloads.Select(payload => new DonXuat
            {
                DXuat_ID = payload.DXuat_ID?.Trim() ?? string.Empty,
                DX_Name = payload.DX_Name?.Trim() ?? string.Empty,
                NV_ID = payload.NV_ID?.Trim() ?? string.Empty,
                DX_Datetime = payload.DX_Datetime
            }).ToList();

            _context.DonXuat.AddRange(DXList);
            await _context.SaveChangesAsync();

            return DXList;
        }

        // DELETE: api/DonXuat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonXuat(string id)
        {
            if (_context.DonXuat == null)
            {
                return NotFound();
            }
            var donXuat = await _context.DonXuat.FindAsync(id);
            if (donXuat == null)
            {
                return NotFound();
            }

            _context.DonXuat.Remove(donXuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonXuatExists(string id)
        {
            return (_context.DonXuat?.Any(e => e.DXuat_ID == id)).GetValueOrDefault();
        }
    }
}
