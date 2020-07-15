using Microsoft.AspNetCore.Mvc;
using Bookshop.Services;
using System.Collections.Generic;
using Bookshop.Models;

namespace Bookshop.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() => _bookService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Book> Get(string id) => _bookService.Get(id);
    }
}
