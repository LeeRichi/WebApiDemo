using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly List<string> _books = new() { "book1", "book2", "book3", "book4", "book5" };
        private readonly List<Book> _anotherBooks = new();

        /*         [HttpGet]
                public IEnumerable<string> GetAllBooks()
                {
                    return _books;
                } */

        /*  [HttpGet()]
         public GetAllBookResponse GetAllBooks([FromQuery] int page = 1 , [FromQuery] int pageSize = 2)
         {
             if(page == 0)
             {
                 return new GetAllBookResponse(1, _books);
             }
             var result = _books.Skip((page-1)*pageSize).Take(pageSize).ToList();
             var totalPages = _books.Count/pageSize;
             if (_books.Count % pageSize != 0) totalPages += 1; //remainder =  count - (count/size)*size
             var response = new GetAllBookResponse(totalPages, result);
             return response;
         } */

        /* [HttpGet()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllBooks([FromQuery] int page = 1, [FromQuery] int pageSize = 2)
        {
            if (page < 0 || pageSize < 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (page == 0)
            {
                return Ok(new GetAllBookResponse(1, _books));
            }
            var result = _books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = _books.Count / pageSize;
            if (_books.Count % pageSize != 0) totalPages += 1; //remainder =  count - (count/size)*size
            var response = new GetAllBookResponse(totalPages, result);
            return Ok(response);
        } */

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GetAllBookResponse> GetAllBooks([FromQuery] int page = 1, [FromQuery] int pageSize = 2)
        {
            if (page < 0 || pageSize < 0)
            {
                return BadRequest("page or pageSize cannot be negative");
            }
            if (page == 0)
            {
                return new GetAllBookResponse(1, _books);
            }
            var result = _books.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = _books.Count / pageSize;
            if (_books.Count % pageSize != 0) totalPages += 1; //remainder =  count - (count/size)*size
            var response = new GetAllBookResponse(totalPages, result);
            return response;
        }

        [HttpGet("{index:int:min(0):max(2)}")] // api/v1/books/1
        public string GetBookByIndex(int index)
        {
            return _books[index];
        }

        [HttpPost]
        public IEnumerable<string> CreateBook([FromBody] string name)
        {
            _books.Add(name);
            return _books;
        }

        [HttpPatch("{index:int}")]
        public IEnumerable<string> UpdateBook([FromRoute] int index, [FromBody] string name)
        {
            _books[index] = name;
            return _books;
        }

        [HttpPost("anotherBooks")]
        public IEnumerable<Book> AddNewBook([FromBody] Book book)
        {
            _anotherBooks.Add(book);
            return _anotherBooks;
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Book(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class GetAllBookResponse
    {
        public int TotalPages { get; set; }
        public IEnumerable<string> Books { get; set; }
        public GetAllBookResponse(int totalPages, IEnumerable<string> books)
        {
            TotalPages = totalPages;
            Books = books;
        }
    }
}