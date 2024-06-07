using Microsoft.AspNetCore.Mvc;
using controle_de_estoque_api.Data;
using controle_de_estoque_api.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_de_estoque_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly ControleEstoqueContext _context;

        public EstoqueController(ControleEstoqueContext context)
        {
            _context = context;
        }

        // GET: api/Estoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoque()
        {
            return await _context.Estoque.ToListAsync();
        }

        // GET: api/Estoque/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
            var produto = await _context.Estoque.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Estoque/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Estoque estoque)
        {
            if (id != estoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
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

        // POST: api/Estoque
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostProduto(Estoque estoque)
        {
            _context.Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.Id }, estoque);
        }

        // DELETE: api/Estoque/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Estoque.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Estoque.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstoqueExists(int id)
        {
            return _context.Estoque.Any(e => e.Id == id);
        }
    }
}
