using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumGate.Auth.Models
{
    public partial class UserData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserData(int id, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Method to display person's info
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nDate of Birth: {DateOfBirth.ToShortDateString()}\nEmail: {Email}\nPhone: {PhoneNumber}";
        }

        public string FullName()
        {
            return $"{LastName}, {FirstName} ";
        }
    }
}
