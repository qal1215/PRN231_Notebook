namespace SE162024.ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWOrk;

        public CategoriesController(UnitOfWork unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var result = await _unitOfWOrk.Categories.GetAsync();
            return Ok(result);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _unitOfWOrk.Categories.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _unitOfWOrk.Categories.Update(category);
                await _unitOfWOrk.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _unitOfWOrk.Categories.InsertAsync(category);
            await _unitOfWOrk.SaveAsync();

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _unitOfWOrk.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWOrk.Categories.Delete(category);
            await _unitOfWOrk.SaveAsync();

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            return await _unitOfWOrk.Categories.IsExist(id);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int id)
        {
            var category = await _unitOfWOrk.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var products = await _unitOfWOrk.Products.GetAsync(p => p.CategoryId == id);
            return Ok(products);
        }
    }
}
