using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Odata_BookStore.Models;

namespace Odata_BookStore.Controllers
{
    [Route("odata/presses")]
    public class PressesController : ODataController
    {
        private readonly BookStoreContext _context;

        public PressesController(BookStoreContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Presses);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_context.Presses.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Press press)
        {
            _context.Presses.Add(press);
            _context.SaveChanges();
            return Created(press);
        }

        [EnableQuery]
        public IActionResult Delete([FromBody] int key)
        {
            var press = _context.Presses.FirstOrDefault(c => c.Id == key);
            if (press != null)
            {
                _context.Presses.Remove(press);
                _context.SaveChanges();
            }
            return Ok();
        }
    }

}
