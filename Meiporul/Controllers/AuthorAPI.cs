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
        public async Task<ActionResult<AuthorAPI.Models.Author>> CreateAuthor(AuthorAPI.Models.Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }
    }
}