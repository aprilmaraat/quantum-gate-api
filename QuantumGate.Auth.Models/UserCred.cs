using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuantumGate.Auth.Models
{
    public class UserCred
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string AuthenticationHash { get; set; }
        public DateTime LastUsedDT { get; set; }
        public bool ResetPassword { get; set; }
        public DateTime? PasswordChangeDT { get; set; }

        [JsonIgnore]
        public virtual UserData User { get; set; }

        public UserCred(int userID, string userName, string authenticationHash, DateTime lastUsedDT, bool resetPassword, DateTime? passwordChangeDT, UserData user)
        {
            UserID = userID;
            UserName = userName;
            AuthenticationHash = authenticationHash;
            LastUsedDT = lastUsedDT;
            ResetPassword = resetPassword;
            PasswordChangeDT = passwordChangeDT;
            User = user;
        }
    }
}
