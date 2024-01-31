using Microsoft.AspNetCore.Mvc;
using QuantumGate.CommonPackages.Models;
using QuantumGateAPI.Services;
using QuantumGate.BookCatalog.Models;
using QuantumGate.CommonPackages.Models.Requests;

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

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] PagedSearchParam searchParam) 
        {
            var response = await _bookService.GetByKeyword(searchParam);

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _bookService.GetById(id);

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book model)
        {
            var response = await _bookService.CreateBook(model);

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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book model)
        {
            var response = await _bookService.UpdateBook(model);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookService.RemoveBook(id);

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
