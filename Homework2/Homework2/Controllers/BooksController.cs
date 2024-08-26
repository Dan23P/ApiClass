using Homework2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Book>> Get() 
        {
            return Ok (StaticDb.Books);
        }
        [HttpGet("byIndex")]
        public ActionResult<Book> GetBookByQueryString(int index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index is negative");
                }

                if (index >= StaticDb.Books.Count)
                {
                    return NotFound("The book was not found");
                }

                return Ok(StaticDb.Books[index]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("byTitle")]
        public ActionResult<Book> GetBookByQueryString(string name)
        {
            try
            {
                if (name == null )
                {
                    return BadRequest("You have not entered a value");
                }
                return Ok(StaticDb.Books.Where(b => b.Title.Equals(name, StringComparison.OrdinalIgnoreCase)));
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("byAuthor")]
        public ActionResult<Book> GetBookQueryString(string author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest("You have not entered a value");
                }
                return Ok(StaticDb.Books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult postBook([FromBody] Book book)
        {
            try
            {
                if (book == null || book.Title == "" || book.Author == "")
                {
                    return BadRequest("You have not entered the Title or the Author of the book");
                }
                
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book added!");
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
