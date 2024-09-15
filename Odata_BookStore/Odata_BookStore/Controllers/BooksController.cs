using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Odata_BookStore.Models;

namespace Odata_BookStore.Controllers
{
    [Route("odata/books")]
    public class BooksController : ODataController
    {
        private BookStoreContext db;

        public BooksController(BookStoreContext context)
        {
            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery(PageSize = 10)]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(db.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return Created(book);
        }

        [EnableQuery]
        public IActionResult Delete([FromBody] int key)
        {
            var book = db.Books.FirstOrDefault(c => c.Id == key);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return Ok();
        }
    }

}
