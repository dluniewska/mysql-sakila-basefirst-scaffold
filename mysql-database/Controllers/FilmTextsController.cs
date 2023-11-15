using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mysql_database.Data;
using mysql_database.sakila;

namespace mysql_database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmTextsController : ControllerBase
    {
        private readonly SakilaContext _context;

        public FilmTextsController(SakilaContext context)
        {
            _context = context;
        }

        // GET: api/FilmTexts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmText>>> GetFilmTexts()
        {
          if (_context.FilmTexts == null)
          {
              return NotFound();
          }
            return await _context.FilmTexts.ToListAsync();
        }

        // GET: api/FilmTexts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmText>> GetFilmText(short id)
        {
          if (_context.FilmTexts == null)
          {
              return NotFound();
          }
            var filmText = await _context.FilmTexts.FindAsync(id);

            if (filmText == null)
            {
                return NotFound();
            }

            return filmText;
        }

        // PUT: api/FilmTexts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmText(short id, FilmText filmText)
        {
            if (id != filmText.FilmId)
            {
                return BadRequest();
            }

            _context.Entry(filmText).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmTextExists(id))
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

        // POST: api/FilmTexts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmText>> PostFilmText(FilmText filmText)
        {
          if (_context.FilmTexts == null)
          {
              return Problem("Entity set 'SakilaContext.FilmTexts'  is null.");
          }
            _context.FilmTexts.Add(filmText);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmText", new { id = filmText.FilmId }, filmText);
        }

        // DELETE: api/FilmTexts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmText(short id)
        {
            if (_context.FilmTexts == null)
            {
                return NotFound();
            }
            var filmText = await _context.FilmTexts.FindAsync(id);
            if (filmText == null)
            {
                return NotFound();
            }

            _context.FilmTexts.Remove(filmText);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmTextExists(short id)
        {
            return (_context.FilmTexts?.Any(e => e.FilmId == id)).GetValueOrDefault();
        }
    }
}
