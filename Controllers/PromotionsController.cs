using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PromotionsCodes.Datas;
using API_PromotionsCodes.Models;

namespace API_PromotionsCodes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly APIPromotionCodesContext _context;

        public PromotionsController(APIPromotionCodesContext context)
        {
            _context = context;
        }

        // GET: api/Promotions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotions>>> GetPromotionsList()
        {
            return await _context.PromotionsList.ToListAsync();
        }

        // GET: api/Promotions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotions>> GetPromotions(int id)
        {
            var promotions = await _context.PromotionsList.FindAsync(id);

            if (promotions == null)
            {
                return NotFound();
            }

            return promotions;
        }

        // PUT: api/Promotions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPromotions(int id, Promotions promotions)
        {
            if (id != promotions.Id)
            {
                return BadRequest();
            }

            _context.Entry(promotions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionsExists(id))
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

        // POST: api/Promotions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Promotions>> PostPromotions(Promotions promotions)
        {
            _context.PromotionsList.Add(promotions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotions", new { id = promotions.Id }, promotions);
        }

        // DELETE: api/Promotions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Promotions>> DeletePromotions(int id)
        {
            var promotions = await _context.PromotionsList.FindAsync(id);
            if (promotions == null)
            {
                return NotFound();
            }

            _context.PromotionsList.Remove(promotions);
            await _context.SaveChangesAsync();

            return promotions;
        }

        private bool PromotionsExists(int id)
        {
            return _context.PromotionsList.Any(e => e.Id == id);
        }
    }
}
