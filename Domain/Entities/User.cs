using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public enum Role
    {
        Admin,
        Customer,
    }

    //[Index(nameof(Email), IsUnique = true)]
    //[Index(nameof(UserName), IsUnique = true)]
    public class User : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        //[EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; } = Role.Customer;

        public int CartID { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
