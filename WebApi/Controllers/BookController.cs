
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private  BookService _bookService;
    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("GetBook")]
    public List<Book> Get()
    {
        return _bookService.GetBooks();
    }
    
    [HttpGet("GetBookById")]
    public Book Get(int id) => _bookService.GetBookBuId(id);
    
    [HttpPost("AddBook")]
    public void Post([FromBody] Book book) => _bookService.Insert(book);
    
    [HttpPut("UpdateBook")]
    public void Put([FromBody] Book book) => _bookService.Update(book);
    
    [HttpDelete("DeleteBook")]
    public void Delete(int id) => _bookService.Delete(id);


}