using Microsoft.EntityFrameworkCore;
using QuantumGate.BookCatalog.EF;
using QuantumGate.BookCatalog.Models;
using QuantumGate.Packages.Models;
using QuantumGateAPI.Services;

namespace QuantumGateAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookCatalogContext _context;
        public BookService(BookCatalogContext context) 
        {
            _context = context;
        }

        public async Task<Response<List<Book>>> GetAll() 
        {
            try 
            {
                var result = await _context.Books.ToListAsync();
                return Response<List<Book>>.Success(result);
            }
            catch (Exception ex) 
            {
                return Response<List<Book>>.Error(ex.Message);
            }
        }
    }
}
