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
    public class NCCController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public NCCController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/NCC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCC>>> GetNCC()
        {
          if (_context.NCC == null)
          {
              return NotFound();
          }
            return await _context.NCC.ToListAsync();
        }

        // GET: api/NCC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NCC>> GetNCC(string id)
        {
          if (_context.NCC == null)
          {
              return NotFound();
          }
            var nCC = await _context.NCC.FindAsync(id);

            if (nCC == null)
            {
                return NotFound();
            }

            return nCC;
        }

        // PUT: api/NCC/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNCC(string id, NCC nCC)
        {
            if (id != nCC.NCC_ID)
            {
                return BadRequest();
            }

            _context.Entry(nCC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCCExists(id))
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

        // POST: api/NCC
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<NCC>>> PostNCC([FromBody] List<NCC> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var NCCList = payloads.Select(payload => new NCC
            {
                NCC_ID = payload.NCC_ID?.Trim() ?? string.Empty,
                NCC_Name = payload.NCC_Name?.Trim() ?? string.Empty,
                NCC_Phone = payload.NCC_Phone?.Trim() ?? string.Empty,
                NCC_Address = payload.NCC_Address?.Trim() ?? string.Empty, 
                NCC_Status = payload.NCC_Status?.Trim() ?? string.Empty
            }).ToList();

            _context.NCC.AddRange(NCCList);
            await _context.SaveChangesAsync();

            return NCCList;
        }

        // DELETE: api/NCC/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNCC(string id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var ncc = await _context.NCC.FindAsync(id);
                    if (ncc == null)
                    {
                        return NotFound();
                    }

                    var donNhap = await _context.DonNhap.FirstOrDefaultAsync(dn => dn.NCC_ID == id);
                    if (donNhap != null)
                    {
                        donNhap.NCC_ID = null;
                    }

                    _context.NCC.Remove(ncc);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return NoContent();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private bool NCCExists(string id)
        {
            return (_context.NCC?.Any(e => e.NCC_ID == id)).GetValueOrDefault();
        }
    }
}
