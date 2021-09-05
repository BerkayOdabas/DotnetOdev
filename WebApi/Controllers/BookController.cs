using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBooks;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBooks;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBooks.CreateBookCommand;
using static WebApi.BookOperations.UpdateBooks.UpdateBookQuery;

namespace WebApi.AddControllers
{

    [ApiController]
    [Route("[controller]s")]

    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("{id}")]

        public IActionResult GetBooksById(int id)
        {
            GetBooksById query = new GetBooksById(_context);

            try
            {
                var result = query.Handle(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // [HttpGet] // Get With Query String
        // public Book Get([FromQuery] string id)
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookQuery bookQuery = new UpdateBookQuery(_context);
            try
            {
                bookQuery.Model = updatedBook;
                bookQuery.Handle(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }




    }

}