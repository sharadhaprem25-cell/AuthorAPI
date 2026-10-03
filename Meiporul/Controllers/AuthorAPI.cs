using AuthorAPI.Data;
using AuthorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorDbContext _context;

        public AuthorsController(AuthorDbContext context)
        {
            _context = context;
        }

        // GET: api/authors
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AuthorAPI.Models.Author>>> GetAuthors()
        {
            return await _context.Authors.Where(a => a.IsActive).ToListAsync();
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorAPI.Models.Author>> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();
            return author;
        }

        // POST: api/authors
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AuthorAPI.Models.Author>> CreateAuthor(AuthorAPI.Models.Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }
        // PUT: api/authors/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAuthor(int id,AuthorAPI.Models.Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            var existingAuthor = await _context.Authors.FindAsync(id);

            if (existingAuthor == null)
            {
                return NotFound();
            }

            existingAuthor.NameEn = author.NameEn;
            existingAuthor.NameTa = author.NameTa;
            existingAuthor.Role = author.Role;
            existingAuthor.BioEn = author.BioEn;
            existingAuthor.BioTa = author.BioTa;
            existingAuthor.PhotoUrl = author.PhotoUrl;
            existingAuthor.SocialLink = author.SocialLink;
            existingAuthor.IsActive = author.IsActive;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}