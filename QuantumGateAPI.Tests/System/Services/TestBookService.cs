using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using QuantumGate.BookCatalog.EF;
using QuantumGate.CommonPackages;
using QuantumGateAPI.Services;
using QuantumGateAPI.Tests.MockData;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumGateAPI.Tests.System.Services
{
    public class TestBookService : IDisposable
    {
        protected readonly BookCatalogContext _context;
        public TestBookService()
        {
            var options = new DbContextOptionsBuilder<BookCatalogContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            _context = new BookCatalogContext(options);

            _context.Database.EnsureCreated();
            GenerateMockData();
        }

        private void GenerateMockData() 
        {
            /// Create mock data
            var categoryList = CategoryMockData.List();
            _context.Categories.AddRange(categoryList);
            _context.SaveChanges();
            var bookList = BookMockData.List();
            var savedCategories = _context.Categories.ToList();
            bookList.ForEach(x =>
            {
                var random = new Random().Next(savedCategories.First().Id, savedCategories.Last().Id);
                x.CategoryId = savedCategories.First(c => c.Id == random).Id;
            });
            _context.Books.AddRange(bookList);
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetAll()
        {
            var service = new BookService(_context);

            /// Act
            var searchParam = new PagedSearchParam 
            {
                RangeTo = DateTime.MaxValue.ToUniversalTime()
            };
            var result = await service.GetByKeyword(searchParam);
            var expected = BookMockData.List();

            /// Assert
            result.TotalCount.Should().Be(expected.Count);
        }

        [Fact]
        public async Task GetById()
        {
            var service = new BookService(_context);

            var result = await service.GetById(2);
            var exprected = await _context.Books.FirstOrDefaultAsync(x => x.Id == 2);

            /// Assert
            result.ResponseObject.Should().Be(exprected);
        }

        [Fact]
        public async Task GetNotExistingById()
        {
            var service = new BookService(_context);

            var result = await service.GetById(100);
            var exprected = await _context.Books.FirstOrDefaultAsync(x => x.Id == 100);

            /// Assert
            result.ResponseObject.Should().BeNull();
            result.ResponseObject.Should().Be(exprected);
        }

        [Fact]
        public async Task NewBook()
        {
            var service = new BookService(_context);

            var model = BookMockData.New();
            var category = await _context.Categories.FirstOrDefaultAsync();
            model.CategoryId = category.Id;
            await service.CreateBook(model);
            var result = _context.Books.Include(x => x.Category);
            var expected = BookMockData.List().Count() + 1;

            /// Assert
            result.Count().Should().Be(expected);
        }

        [Fact]
        public async Task UpdateBook()
        {
            var service = new BookService(_context);

            var model = await _context.Books.FirstOrDefaultAsync();
            /// Assert
            model.Should().NotBeNull();

            var newTitle = "Wow";
            model.Title = newTitle;
            var result = await service.UpdateBook(model);
            var expected = await _context.Books.FirstOrDefaultAsync(x => x.Id == model.Id);

            /// Assert
            result.ResponseObject.Should().Be(expected);
        }

        [Fact]
        public async Task UpdateNonExistingBook()
        {
            var service = new BookService(_context);

            var model = await _context.Books.FirstOrDefaultAsync(x => x.Id == 1);
            /// Assert
            model.Should().NotBeNull();
            _context.Books.Remove(model);
            _context.SaveChanges();
            model.Title = "Hello";
            var result = await service.UpdateBook(model);
            /// Assert
            result.ResponseObject.Should().BeNull();
        }

        [Fact]
        public async Task DeleteBook()
        {
            var service = new BookService(_context);

            var model = await _context.Books.FirstOrDefaultAsync();
            var id = model.Id;
            await service.RemoveBook(id);
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            /// Assert
            result.Should().BeNull();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
