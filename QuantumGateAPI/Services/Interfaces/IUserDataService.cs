using QuantumGate.Auth.Models;

namespace QuantumGateAPI.Services
{
    public interface IUserDataService
    {
        Task<UserData> GetUserByIdAsync(Guid userId);
    }
}
