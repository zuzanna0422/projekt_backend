using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt_backend.Core.Entities;
using projekt_backend.Infrastructure.Persistence;

namespace projekt_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SnacksController : ControllerBase
    {
        private readonly SnacksContext _context;

        public SnacksController(SnacksContext context)
        {
            _context = context;
        }

        // GET: api/snacks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var snacks = await _context.Snacks.ToListAsync();
            return Ok(snacks);
        }

        // POST: api/snacks
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Snack snack)
        {
            _context.Snacks.Add(snack);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = snack.Id }, snack);
        }

        // PUT: api/snacks/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Snack snack)
        {
            var existing = await _context.Snacks.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.CompetitorName = snack.CompetitorName;
            existing.Chocolate = snack.Chocolate;
            existing.Fruity = snack.Fruity;
            existing.Caramel = snack.Caramel;
            existing.PeanutyAlmondy = snack.PeanutyAlmondy;
            existing.Nougat = snack.Nougat;
            existing.CrispedRiceWafer = snack.CrispedRiceWafer;
            existing.Hard = snack.Hard;
            existing.Bar = snack.Bar;
            existing.Pluribus = snack.Pluribus;
            existing.SugarPercent = snack.SugarPercent;
            existing.PricePercent = snack.PricePercent;
            existing.WinPercent = snack.WinPercent;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/snacks/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
                return NotFound();

            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
