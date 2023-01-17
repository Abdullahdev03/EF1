using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class BookService
{
    private readonly DataContext _context;

    public BookService(DataContext context)
    {
        _context = context;
    }
    
    //Select * from books
    public List<Book> GetBooks()
    {
        var books =  _context.Books.ToList();
        return  books;
    }
    //insert
    public int Insert(Book book)
    {
        _context.Add(book);
        var inserted = _context.SaveChanges();
        return inserted;
    }
    //update
    public int Update(Book model)
    {
        var book = _context.Books.Find(model.Id);
        book.Name = model.Name;
        book.Author = model.Author;
        book.NumberOfPages = model.NumberOfPages;
        var updated = _context.SaveChanges();
        return updated;
    }

    public Book GetBookBuId(int id)
    {
        var book = _context.Books.Find(id);
        return book;
    }

    public int Delete(int id)
    {
        var book = _context.Books.Find(id);
        _context.Books.Remove(book);
        return -_context.SaveChanges();

    }
}