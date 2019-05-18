using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GT.Models;
using GT.Storage;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeedsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DeedsController()
        {
            _context = new ApplicationContext();
        }

        // GET: api/Deeds
        [HttpGet]
        public IEnumerable<Deed> GetDeeds()
        {
            var t = _context.Deeds; ;
            return _context.Deeds;
        }

        // GET: api/Deeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeed([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deed = await _context.Deeds.FindAsync(id);

            if (deed == null)
            {
                return NotFound();
            }

            return Ok(deed);
        }

        // PUT: api/Deeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeed([FromRoute] Guid id, [FromBody] Deed deed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deed.DeedId)
            {
                return BadRequest();
            }

            _context.Entry(deed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeedExists(id))
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

        // POST: api/Deeds
        [HttpPost]
        public async Task<IActionResult> PostDeed([FromBody] Deed deed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Deeds.Add(deed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeed", new { id = deed.DeedId }, deed);
        }

        // DELETE: api/Deeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeed([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deed = await _context.Deeds.FindAsync(id);
            if (deed == null)
            {
                return NotFound();
            }

            _context.Deeds.Remove(deed);
            await _context.SaveChangesAsync();

            return Ok(deed);
        }

        private bool DeedExists(Guid id)
        {
            return _context.Deeds.Any(e => e.DeedId == id);
        }
    }
}