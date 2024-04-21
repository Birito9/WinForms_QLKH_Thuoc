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
    public class PermissionController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public PermissionController(QLKH_ThuocContext context)
        {
            _context = context;
        }

        // GET: api/Permission_
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermission()
        {
          if (_context.Permission == null)
          {
              return NotFound();
          }
            return await _context.Permission.ToListAsync();
        }

        // GET: api/Permission_/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> GetPermission(string id)
        {
          if (_context.Permission == null)
          {
              return NotFound();
          }
            var permission = await _context.Permission.FindAsync(id);

            if (permission == null)
            {
                return NotFound();
            }

            return permission;
        }

        // PUT: api/Permission_/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission(string id, Permission permission)
        {
            if (id != permission.PermissionID)
            {
                return BadRequest();
            }

            _context.Entry(permission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
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

        // POST: api/Permission_
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Permission>> PostPermission(Permission permission)
        {
          if (_context.Permission == null)
          {
              return Problem("Entity set 'QLKH_ThuocContext.Permission'  is null.");
          }
            _context.Permission.Add(permission);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PermissionExists(permission.PermissionID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPermission", new { id = permission.PermissionID }, permission);
        }

        // DELETE: api/Permission_/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(string id)
        {
            if (_context.Permission == null)
            {
                return NotFound();
            }
            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionExists(string id)
        {
            return (_context.Permission?.Any(e => e.PermissionID == id)).GetValueOrDefault();
        }
    }
}
