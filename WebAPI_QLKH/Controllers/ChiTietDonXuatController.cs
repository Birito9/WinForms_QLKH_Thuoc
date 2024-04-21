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
    public class ChiTietDonXuatController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public ChiTietDonXuatController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietDonXuat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietDonXuat>>> GetChiTietDonXuat()
        {
          if (_context.ChiTietDonXuat == null)
          {
              return NotFound();
          }
            return await _context.ChiTietDonXuat.ToListAsync();
        }

        // GET: api/ChiTietDonXuat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietDonXuat>> GetChiTietDonXuat(string id)
        {
          if (_context.ChiTietDonXuat == null)
          {
              return NotFound();
          }
            var chiTietDonXuat = await _context.ChiTietDonXuat.FirstOrDefaultAsync(x => x.DXuat_ID == id);

            if (chiTietDonXuat == null)
            {
                return NotFound();
            }

            return chiTietDonXuat;
        }

        // PUT: api/ChiTietDonXuat/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutChiTietDonXuat(string id, ChiTietDonXuat chiTietDonXuat)
        //{
        //    if (id != chiTietDonXuat.DXuat_ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(chiTietDonXuat).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ChiTietDonXuatExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietDonXuat(string id, ChiTietDonXuat chiTietDonXuat)
        {
            if (id != chiTietDonXuat.DXuat_ID)
            {
                return BadRequest("DXuat_ID mismatch");
            }

            // Tiếp tục xử lý như bình thường

            _context.Entry(chiTietDonXuat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDonXuatExists(id))
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



        // POST: api/ChiTietDonXuat
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietDonXuat>> PostChiTietDonXuat(ChiTietDonXuat chiTietDonXuat)
        {
          if (_context.ChiTietDonXuat == null)
          {
              return Problem("Entity set 'QLKH_ThuocContext.ChiTietDonXuat'  is null.");
          }
            _context.ChiTietDonXuat.Add(chiTietDonXuat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChiTietDonXuatExists(chiTietDonXuat.Thuoc_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChiTietDonXuat", new { id = chiTietDonXuat.Thuoc_ID }, chiTietDonXuat);
        }

        // DELETE: api/ChiTietDonXuat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietDonXuat(string id)
        {
            if (_context.ChiTietDonXuat == null)
            {
                return NotFound();
            }
            var chiTietDonXuat = await _context.ChiTietDonXuat.FindAsync(id);
            if (chiTietDonXuat == null)
            {
                return NotFound();
            }

            _context.ChiTietDonXuat.Remove(chiTietDonXuat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietDonXuatExists(string id)
        {
            return (_context.ChiTietDonXuat?.Any(e => e.Thuoc_ID == id)).GetValueOrDefault();
        }
    }
}
