using QuantumGate.Auth.Models;
using QuantumGateAPI.Utilities.Helper;

namespace QuantumGateAPI.Services
{
    public interface IUserDataService
    {
        Task<PagedResult<UserData>> GetUserDataAsync(int pageNumber, int pageSize);
        Task<UserData> GetUserByIdAsync(Guid userId);
    }
}
