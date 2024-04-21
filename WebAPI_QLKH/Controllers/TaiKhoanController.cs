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
    public class TaiKhoanController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public TaiKhoanController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/TaiKhoan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> GetTaiKhoan()
        {
          if (_context.TaiKhoan == null)
          {
              return NotFound();
          }
            return await _context.TaiKhoan.ToListAsync();
        }

        // GET: api/TaiKhoan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiKhoan>> GetTaiKhoan(string id)
        {
          if (_context.TaiKhoan == null)
          {
              return NotFound();
          }
            var taiKhoan = await _context.TaiKhoan.FindAsync(id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            return taiKhoan;
        }

        // PUT: api/TaiKhoan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiKhoan(string id, [FromBody] TaiKhoan payload)
        {
            var taiKhoan = await _context.TaiKhoan.FindAsync(id);

            if (taiKhoan == null)
            {
                return NotFound();
            }

            taiKhoan.Description = payload.Description;
            taiKhoan.RoleID = payload.RoleID;
            taiKhoan.UserName = payload.UserName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiKhoanExists(id))
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

        // POST: api/TaiKhoan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TaiKhoan>>> PostTaiKhoan([FromBody] List<TaiKhoan> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var TaiKhoanList = payloads.Select(payload => new TaiKhoan
            {
                UserID = payload.UserID.Trim(),
                RoleID = payload.RoleID.Trim(),
                UserName = payload.UserName.Trim(),
                Password = payload.Password.Trim(),
                Description = payload.Description.Trim()
            }).ToList();

            _context.TaiKhoan.AddRange(TaiKhoanList);
            await _context.SaveChangesAsync();

            return TaiKhoanList;
        }

        // DELETE: api/TaiKhoan/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTaiKhoan(string id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var taiKhoan = await _context.TaiKhoan.FindAsync(id);
                    if (taiKhoan == null)
                    {
                        return NotFound();
                    }

                    var nhanVien = await _context.NhanVien.FirstOrDefaultAsync(nv => nv.UserID == id);
                    if (nhanVien != null)
                    {
                        nhanVien.UserID = null;
                        await _context.SaveChangesAsync();
                    }

                    _context.TaiKhoan.Remove(taiKhoan);
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


        private bool TaiKhoanExists(string id)
        {
            return (_context.TaiKhoan?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
    }
}
