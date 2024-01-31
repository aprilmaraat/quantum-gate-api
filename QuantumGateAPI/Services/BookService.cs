using Microsoft.EntityFrameworkCore;
using QuantumGate.BookCatalog.EF;
using QuantumGate.BookCatalog.Models;
using QuantumGate.CommonPackages;
using QuantumGateAPI.Services.Interfaces;

namespace QuantumGateAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookCatalogContext _context;
        public BookService(BookCatalogContext context) 
        {
            _context = context;
        }

        public async Task<PagedResponse<Book>> GetByKeyword(PagedSearchParam searchParam) 
        {
            try 
            {
                var objects = await _context.Books
                    .Where(x =>
                           (
                            x.Title.ToLower().Contains(searchParam.Keyword.ToLower())
                            || x.Description.ToLower().Contains(searchParam.Keyword.ToLower())
                           )
                        && (
                            DateTime.Compare(x.PublishDateUtc, searchParam.RangeFrom.ToUniversalTime()) > 0
                            && DateTime.Compare(x.PublishDateUtc, searchParam.RangeTo.ToUniversalTime()) < 0)
                    ).Include(x => x.Category).ToListAsync();
                var list = objects
                    .Skip((searchParam.PageNumber - 1) * searchParam.PageSize)
                    .Take(searchParam.PageSize)
                    .ToList();
                var result = new PagedResponse<Book>
                {
                    ResponseObjects = list,
                    TotalCount = objects.Count,
                    TotalPages = (int)Math.Ceiling((double)objects.Count / searchParam.PageSize),
                    CurrentPage = searchParam.PageNumber,
                    PageSize = searchParam.PageSize
            };
                return result;
            }
            catch (Exception ex) 
            {
                return PagedResponse<Book>.Error(ex.Message);
            }
        }

        public async Task<Response<Book>> GetById(int id) 
        {
            try
            {
                var result = await _context.Books.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
                if(result == null) return Response<Book>.Error("Data can't be found.");
                return Response<Book>.Success(responseObject: result);
            }
            catch (Exception ex)
            {
                return Response<Book>.Error(ex.Message);
            }
        }

        public async Task<Response<Book>> CreateBook(Book model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Books.AddAsync(model);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Response<Book>.Success(model);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response<Book>.Error(ex.Message);
                }
            }
        }

        public async Task<Response<Book>> UpdateBook(Book model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == model.Id);
                    if (book == null) return Response<Book>.Error("Data doesn't exist.");

                    book.CategoryId = model.CategoryId;
                    book.Title = model.Title;
                    book.Description = model.Description;
                    book.PublishDateUtc = model.PublishDateUtc;

                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Response<Book>.Success(model);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response<Book>.Error(ex.Message);
                }
            }
        }

        public async Task<Response<bool>> RemoveBook(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
                    if (book == null) return Response<bool>.Error("Data no longer exists.");

                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return Response<bool>.Success(true);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return Response<bool>.Error(ex.Message);
                }
            }
        }
    }
}
