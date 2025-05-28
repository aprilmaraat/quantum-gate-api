using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuantumGate.Auth.Models
{
    public class UserCred : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string AuthenticationHash { get; set; } = string.Empty;
        public DateTime LastUsedDT { get; set; } 
        public bool ResetPassword { get; set; }
        public DateTime? PasswordChangeDT { get; set; }
        public Guid UserDataId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserDataId))]
        public virtual UserData UserData { get; set; } = null!;

        public UserCred(Guid id, string userName, string authenticationHash, DateTime lastUsedDT, bool resetPassword, DateTime? passwordChangeDT)
        {
            Id = id;
            UserName = userName;
            AuthenticationHash = authenticationHash;
            LastUsedDT = lastUsedDT;
            ResetPassword = resetPassword;
            PasswordChangeDT = passwordChangeDT;
        }
    }
}
