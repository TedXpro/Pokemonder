using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers{
    [ApiController]
    [Route("[Controller]")]
    public class BookController : ControllerBase{
        private readonly IBookServices? _bookServices;
        public BookController(IBookServices bookServices){
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetBooks(){
            try
            {
                return Ok(await _bookServices?.GetBooks()!);
            }
            catch(Exception){
                return NotFound("No books found");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(string id){
            try{
                return Ok(await _bookServices?.GetBook(id)!);
            } catch (Exception){
                return NotFound($"No book found with id => {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddBook(Book newBook){
            try{
                return Ok(await _bookServices?.AddBook(newBook)!);
            } catch(Exception){
                return BadRequest("Failed to add book");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(string id, Book book){
            try{
                return Ok(await _bookServices?.UpdateBook(id, book)!);
            }catch(Exception){
                return BadRequest("Failed to update book");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(string id){
            try{
                return Ok(await _bookServices?.DeleteBook(id)!);
            } catch(Exception){
                return BadRequest("Failed to Delete book!");
            }
        }

        [HttpGet("/title/{title}")]
        public async Task<ActionResult> GetBookByTitle(string title){
            try{
                return Ok(await _bookServices?.GetBookByTitle(title)!);
            } catch(Exception){
                return NotFound($"No book found with title => {title}");
            }
        }
    }   
}