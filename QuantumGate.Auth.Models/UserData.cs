using System.Text.Json.Serialization;

namespace QuantumGate.Auth.Models
{
    public partial class UserData : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCred> UserCreds { get; set; } = new List<UserCred>();

        public UserData(Guid id, string firstName, string lastName, DateTime dateOfBirth, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
    }
}
