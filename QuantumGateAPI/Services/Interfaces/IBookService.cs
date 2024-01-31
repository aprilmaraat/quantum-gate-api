using QuantumGate.BookCatalog.Models;
using QuantumGate.CommonPackages.Models;
using QuantumGate.CommonPackages.Models.Requests;

namespace QuantumGateAPI.Services
{
    public interface IBookService
    {
        Task<PagedResponse<Book>> GetByKeyword(PagedSearchParam searchParam);
        Task<Response<Book>> GetById(int id);
        Task<Response<Book>> CreateBook(Book model);
        Task<Response<Book>> UpdateBook(Book model);
        Task<Response<bool>> RemoveBook(int id);
    }
}
