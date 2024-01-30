using Microsoft.AspNetCore.Mvc;
using QuantumGate.Packages.Models;
using QuantumGateAPI.Services;

namespace QuantumGateAPI.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService) 
        {
            _bookService = bookService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() 
        {
            var response = await _bookService.GetAll();

            switch (response.State)
            {
                case ResponseState.Exception:
                    return StatusCode(500, response.Exception.Message);
                case ResponseState.Error:
                    return BadRequest(response.MessageText);
                default:
                    return Ok(response);
            }
        }
    }
}
