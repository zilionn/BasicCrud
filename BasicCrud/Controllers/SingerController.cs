using BasicCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SingerController : ControllerBase {

        private readonly SingerContext _context;

        public SingerController(SingerContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Singer>>> GetSingers() { 
        
            if(_context.Singer == null) {
                return NotFound();
            }
            return await _context.Singer.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Singer>> GetSingerById(int id) {
            if(_context.Singer == null) {
                return NotFound();
            }

            var Singer = await _context.Singer.FindAsync(id);
            if (Singer == null) {
                return NotFound();
            }
            return Singer;
        }

        [HttpPost]
        public async Task<ActionResult<Singer>> PostSinger(Singer singer) {
            _context.Singer.Add(singer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSingerById), new { id = singer.Id }, singer);
        }

        [HttpPut]
        public async Task<ActionResult<Singer>> PutSinger(int id, Singer singer) {
            if(id != singer.Id) {
                return BadRequest();
            }

            var SingerReference = _context.Singer.AsNoTracking().FirstOrDefault(x => x.Id == singer.Id);
            if (SingerReference == null) {
                return NotFound();
            }
            _context.Singer.Update(singer);
            await _context.SaveChangesAsync();

            return Ok(singer);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSinger(int id) { 
        
            var SingerReference = _context.Singer.AsNoTracking().FirstOrDefault(x =>x.Id == id);
            if (SingerReference == null) {
                return NotFound(id);
            }

            _context.Singer.Remove(SingerReference);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
