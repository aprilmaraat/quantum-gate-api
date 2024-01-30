using QuantumGate.BookCatalog.Models;
using QuantumGate.Packages.Models;

namespace QuantumGateAPI.Services
{
    public interface IBookService
    {
        Task<Response<List<Book>>> GetAll();
    }
}
