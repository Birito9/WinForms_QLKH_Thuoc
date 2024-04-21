using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI_QLKH.Models;
using WebAPI_QLKH.Services;

namespace WebAPI_QLKH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiNhanhController : ControllerBase
    {
        private readonly QLKH_ThuocContext _context;

        public ChiNhanhController(QLKH_ThuocContext context)
        {
            _context = context;
        }
        public class ChiNhanhPost
        {
            public string CN_ID { get; set; }
            public string CN_Name { get; set; }
            public string CN_Address { get; set; }
        }
        public class ChiNhanhPayloadPut
        {
            public string CN_Name { get; set; }
            public string CN_Address { get; set; }
        }

        // GET: api/ChiNhanh
        [HttpGet]
        public IActionResult GetChiNhanh()
        {
            var chiNhanhs = _context.ChiNhanh.ToList();
            return Ok(chiNhanhs);
        }

        // GET: api/ChiNhanh/5
        [HttpGet("{id}")]
        public IActionResult GetChiNhanh(string id)
        {
            var chiNhanh = _context.ChiNhanh.Find(id);

            if (chiNhanh == null)
            {
                return NotFound();
            }

            return Ok(chiNhanh);
        }
        private bool ChiNhanhExists(string id)
        {
            return _context.ChiNhanh.Any(e => e.CN_ID == id);
        }

        // POST: api/ChiNhanh
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ChiNhanh>>> PostChiNhanh([FromBody] List<ChiNhanhPost> payloads)
        {
            if (payloads == null || !payloads.Any())
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var chiNhanhList = payloads.Select(payload => new ChiNhanh
            {
                CN_ID = payload.CN_ID.Trim(),
                CN_Name = payload.CN_Name.Trim(),
                CN_Address = payload.CN_Address.Trim()
            }).ToList();

            _context.ChiNhanh.AddRange(chiNhanhList);
            await _context.SaveChangesAsync();

            return chiNhanhList;
        }

        // PUT: api/ChiNhanh/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiNhanh(string id, [FromBody] ChiNhanhPayloadPut payload)
        {
            if (payload == null || string.IsNullOrEmpty(payload.CN_Name) || string.IsNullOrEmpty(payload.CN_Address))
            {
                return BadRequest("Danh sách payload không hợp lệ");
            }

            var chiNhanh = await _context.ChiNhanh.FindAsync(id);

            if (chiNhanh == null)
            {
                return NotFound();
            }

            chiNhanh.CN_Name = payload.CN_Name;
            chiNhanh.CN_Address = payload.CN_Address;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiNhanhExists(id))
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

        // DELETE: api/ChiNhanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiNhanh(string id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var chiNhanh = await _context.ChiNhanh.FindAsync(id);
                    if (chiNhanh == null)
                    {
                        return NotFound();
                    }

                    string defaultCN_ID = "CN1";

                    UpdateCN_ID(id, defaultCN_ID);

                    _context.ChiNhanh.Remove(chiNhanh);

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

        private void UpdateCN_ID(string currentID, string newID)
        {
            _context.ChiTietDonNhap.Where(ctdn => ctdn.DNhap.NV_ID == currentID)
                .ToList()
                .ForEach(ctdn => ctdn.DNhap.NV_ID = newID);

            _context.DonNhap.Where(dn => dn.NV_ID == currentID)
                .ToList()
                .ForEach(dn => dn.NV_ID = newID);

            _context.ChiTietDonXuat.Where(ctdx => ctdx.DXuat.NV_ID == currentID)
                .ToList()
                .ForEach(ctdx => ctdx.DXuat.NV_ID = newID);

            _context.DonXuat.Where(dx => dx.NV_ID == currentID)
                .ToList()
                .ForEach(dx => dx.NV_ID = newID);

            _context.ChiTietThuoc.Where(ctt => ctt.Lo.Kho.CN_ID == currentID)
                .ToList()
                .ForEach(ctt => ctt.Lo.Kho.CN_ID = newID);

            _context.Lo.Where(lo => lo != null && lo.Kho != null && lo.Kho.CN_ID == currentID)
                .ToList()
                .ForEach(lo =>
                {
                    if (lo.Kho != null)
                    {
                        lo.Kho.CN_ID = newID;
                    }
                });

            _context.Kho.Where(kho => kho.CN_ID == currentID)
                .ToList()
                .ForEach(kho => kho.CN_ID = newID);

            _context.NhanVien.Where(nv => nv.CN_ID == currentID)
                .ToList()
                .ForEach(nv => nv.CN_ID = newID);
        }
    }
}
