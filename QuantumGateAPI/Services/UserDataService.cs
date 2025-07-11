using QuantumGate.Auth.EF;
using QuantumGate.Auth.Models;
using QuantumGateAPI.Utilities.Helper;
using Microsoft.EntityFrameworkCore;

namespace QuantumGateAPI.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly QuantumGateAuthDbContext _context;
        public UserDataService(QuantumGateAuthDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<UserData>> GetUserDataAsync(int pageNumber, int pageSize)
        {
            var query = _context.UserData.AsQueryable();
            // Apply pagination
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return new PagedResult<UserData>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<UserData> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.UserData.FindAsync(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }
            return user;
        }
    }
}
